namespace PwshVirt;

using System.Collections.Concurrent;
using System.Globalization;

public abstract class PwshVirtCmdlet : PSCmdlet, IDisposable
{
    private bool disposed;

    private ConcurrentQueue<Message?>? messages;

    private ManualResetEventSlim? hasMessage;

    private bool workIsCompleted;

    static PwshVirtCmdlet()
    {
        // CancelKeyPress からすべてのコールバックを削除すると、
        // その後に追加したコールバックが呼び出されなくなるため、
        // ダミーで 1 つ登録しておく。
        Console.CancelKeyPress += (a, b) => { };
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing)
        {
            this.messages = null;
            this.hasMessage?.Dispose();
            this.hasMessage = null;
        }

        this.disposed = true;
    }

    internal CancellationTokenSource? Cancellation
    {
        get;
        private set;
    }

    internal abstract Task Execute();

    internal Connection GetConnection(Connection? value, out bool isDefault)
    {
        isDefault = false;

        if (value is null)
        {
            value = this.GetVariableValue(Connection.DefaultVirtServer) as Connection;
            isDefault = value is not null;
        }

        return value is null ? throw new PwshVirtException(Resource.ERR_ShouldConnectVirtServer, ErrorCategory.InvalidOperation) : value;
    }

    internal void SetProgress(
        string activity,
        int percentComplete)
    {
        this.SetProgress(0, activity, "Processing", percentComplete, percentComplete >= 100);
    }

    internal void SetProgress(
        int activityId,
        string activity,
        string statusDescription,
        int percentComplete,
        bool isCompleted)
    {
        var progress = new Progress(activityId, activity, statusDescription, percentComplete, isCompleted);
        this.SetMessage(progress);
    }

    internal void SetResult(object sendToPipeline)
    {
        this.SetResult(sendToPipeline, false);
    }

    internal void SetResult(object sendToPipeline, bool enumerateCollection)
    {
        this.SetMessage(new Result(sendToPipeline, enumerateCollection));
    }

    internal void SetVariable(string name, object value)
    {
        this.SessionState.PSVariable.Set(name, value);
    }

    internal async Task Work()
    {
        try
        {
            await this.Execute().ConfigureAwait(false);
            this.SetWorkCompleted();
        }
        catch
        {
            this.SetWorkCompleted();
            throw;
        }
    }

    protected override void BeginProcessing()
    {
        this.messages = new ConcurrentQueue<Message?>();
        this.hasMessage = new ManualResetEventSlim();
    }

    protected override void EndProcessing()
    {
        this.Dispose();
    }

    protected sealed override void ProcessRecord()
    {
        try
        {
            this.SetWorkStarting();
            var job = Task.Run(this.Work, this.Cancellation!.Token);

            while (!this.workIsCompleted)
            {
                this.hasMessage!.Wait();
                var msg = this.GetMessage();
                if (msg is null)
                {
                    break;
                }

                switch (msg)
                {
                    case Progress p:
                        var record = new ProgressRecord(p.ActivityId, p.Activity, p.StatusDescription)
                        {
                            PercentComplete = p.PercentComplete,
                            RecordType = p.IsCompleted ? ProgressRecordType.Completed : ProgressRecordType.Processing,
                        };
                        this.WriteProgress(record);
                        break;
                    case Result r:
                        this.WriteObject(r.SendToPipeline, r.EnumerateCollection);
                        break;
                    default:
                        throw new InvalidProgramException();
                }
            }

            job.Wait();
        }
        catch (AggregateException ae) when (ae.InnerException is PwshVirtException e)
        {
            this.WriteVerbose(string.Format(CultureInfo.CurrentCulture, "{0}", e));

            var error = new ErrorRecord(e, e.GetType().FullName, e.Category, this);
            this.ThrowTerminatingError(error);
        }
        catch (AggregateException ae)
        {
            this.WriteVerbose(string.Format(CultureInfo.CurrentCulture, "{0}", ae.InnerException));

            var e = ae.InnerException!;
            var error = new ErrorRecord(e, e.GetType().FullName, ErrorCategory.NotSpecified, this);
            this.ThrowTerminatingError(error);
        }
        catch (Exception e)
        {
            this.WriteVerbose(string.Format(CultureInfo.CurrentCulture, "{0}", e));

            var error = new ErrorRecord(e, e.GetType().FullName, ErrorCategory.NotSpecified, this);
            this.ThrowTerminatingError(error);
        }
    }

    private void CancelByKey(object? sender, ConsoleCancelEventArgs e)
    {
        if (!this.Cancellation!.IsCancellationRequested)
        {
            this.Cancellation.Cancel(true);
        }
    }

    private void DisableConsoleCancelKey()
    {
        Console.CancelKeyPress += this.CancelByKey;
    }

    private void EnableConsoleCancelKey()
    {
        Console.CancelKeyPress -= this.CancelByKey;
    }

    private Message? GetMessage()
    {
        lock (this.messages!)
        {
            _ = this.messages.TryDequeue(out var result);

            if (result is null)
            {
                return null;
            }
            else if (this.messages!.IsEmpty)
            {
                this.hasMessage!.Reset();
            }

            return result;
        }
    }

    private void SetMessage(Message message)
    {
        lock (this.messages!)
        {
            this.messages.Enqueue(message);
            this.hasMessage!.Set();
        }
    }

    private void SetWorkCompleted()
    {
        lock (this.messages!)
        {
            this.workIsCompleted = true;
            this.messages.Enqueue(null);
            this.hasMessage!.Set();
            this.Cancellation!.Dispose();
        }

        this.EnableConsoleCancelKey();
    }

    private void SetWorkStarting()
    {
        this.workIsCompleted = false;
        this.Cancellation = new CancellationTokenSource();
        this.hasMessage!.Reset();
        this.DisableConsoleCancelKey();
    }
}
