namespace PwshVirt;

using System.Collections.Concurrent;

public abstract class PwshVirtCmdlet : PSCmdlet
{
    private ConcurrentQueue<Tuple<object, bool>?>? results;

    private ManualResetEventSlim? hasResult;

    private bool workIsCompleted;

    static PwshVirtCmdlet()
    {
        // CancelKeyPress からすべてのコールバックを削除すると、
        // その後に追加したコールバックが呼び出されなくなるため、
        // ダミーで 1 つ登録しておく。
        Console.CancelKeyPress += (a, b) => { };
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

        if (value is null)
        {
            throw new PwshVirtException(ErrorCategory.InvalidOperation);
        }

        return value;
    }

    internal void SetResult(object sendToPipeline)
    {
        this.SetResult(sendToPipeline, false);
    }

    internal void SetResult(object sendToPipeline, bool enumerateCollection)
    {
        lock (this.results!)
        {
            this.results.Enqueue(new Tuple<object, bool>(sendToPipeline, enumerateCollection));
            this.hasResult!.Set();
        }
    }

    internal void SetVariable(string name, object value)
    {
        this.SessionState.PSVariable.Set(name, value);
    }

    internal async Task Work()
    {
        try
        {
            await this.Execute();
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
        this.results = new ConcurrentQueue<Tuple<object, bool>?>();
        this.hasResult = new ManualResetEventSlim();
    }

    protected override void EndProcessing()
    {
        this.results = null;
        this.hasResult!.Dispose();
        this.hasResult = null;
    }

    protected override sealed void ProcessRecord()
    {
        try
        {
            this.SetWorkStarting();
            var job = Task.Run(this.Work, this.Cancellation!.Token);

            while (!this.workIsCompleted)
            {
                this.hasResult!.Wait();
                var result = this.GetResult();
                if (result is null)
                {
                    break;
                }

                (var sendToPipeline, var enumerateCollection) = result;
                this.WriteObject(sendToPipeline, enumerateCollection);
            }

            job.Wait();
        }
        catch (AggregateException ae) when (ae.InnerException is PwshVirtException e)
        {
            this.WriteVerbose(string.Format("{0}", e));

            var error = new ErrorRecord(e, e.GetType().FullName, e.Category, this);
            this.ThrowTerminatingError(error);
        }
        catch (AggregateException ae)
        {
            this.WriteVerbose(string.Format("{0}", ae.InnerException));

            var e = ae.InnerException!;
            var error = new ErrorRecord(e, e.GetType().FullName, ErrorCategory.NotSpecified, this);
            this.ThrowTerminatingError(error);
        }
        catch (Exception e)
        {
            this.WriteVerbose(string.Format("{0}", e));

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

    private Tuple<object, bool>? GetResult()
    {
        lock (this.results!)
        {
            this.results.TryDequeue(out var result);

            if (result is null)
            {
                return null;
            }
            else if (this.results!.IsEmpty)
            {
                this.hasResult!.Reset();
            }

            return result;
        }
    }

    private void SetWorkCompleted()
    {
        lock (this.results!)
        {
            this.workIsCompleted = true;
            this.results.Enqueue(null);
            this.hasResult!.Set();
            this.Cancellation!.Dispose();
        }

        this.EnableConsoleCancelKey();
    }

    private void SetWorkStarting()
    {
        this.workIsCompleted = false;
        this.Cancellation = new CancellationTokenSource();
        this.hasResult!.Reset();
        this.DisableConsoleCancelKey();
    }
}
