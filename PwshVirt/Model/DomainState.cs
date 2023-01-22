namespace PwshVirt;

public enum DomainState
{
    NoState = 0,

    Running = 1,

    Blocked = 2,

    Paused = 3,

    Shutdown = 4,

    Shutoff = 5,

    Crashed = 6,

    PmSuspended = 7,

    Last = 8,
}
