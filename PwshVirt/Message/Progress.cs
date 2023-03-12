namespace PwshVirt;

internal class Progress : Message
{
    internal Progress(
        int activityId,
        string activity,
        string statusDescription,
        int percentComplete,
        bool isCompleted)
    {
        this.ActivityId = activityId;
        this.Activity = activity;
        this.StatusDescription = statusDescription;
        this.PercentComplete = percentComplete;
        this.IsCompleted = isCompleted;
    }

    internal int ActivityId { get; }

    internal string Activity { get; }

    internal bool IsCompleted { get; }

    internal int PercentComplete { get; }

    internal string StatusDescription { get; }
}
