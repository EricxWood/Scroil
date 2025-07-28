using System;
using System.Runtime.InteropServices;

class MultimediaTimer : IDisposable
{
    private int intervalMs;
    private uint timerId;
    private TimeProc timeProc;

    public delegate void TimerTickHandler();
    public event TimerTickHandler? OnTick;

    public MultimediaTimer(int intervalMs)
    {
        this.intervalMs = intervalMs;
        this.timeProc = new TimeProc(Callback);
    }

    public void Start()
    {
        if (timerId != 0)
            return; // Already started

        timerId = timeSetEvent(
            (uint)intervalMs,       // Delay
            0,                      // Resolution (0 = best)
            timeProc,               // Callback
            UIntPtr.Zero,           // User data
            1                       // Periodic
        );
    }

    public void Stop()
    {
        if (timerId != 0)
        {
            timeKillEvent(timerId);
            timerId = 0;
        }
    }

    private void Callback(uint id, uint msg, UIntPtr user, UIntPtr dw1, UIntPtr dw2)
    {
        OnTick?.Invoke();
    }

    public void Dispose()
    {
        Stop();
    }

    // P/Invoke for WinMM multimedia timer
    private delegate void TimeProc(uint uID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2);

    [DllImport("winmm.dll", SetLastError = true)]
    private static extern uint timeSetEvent(uint msDelay, uint msResolution, TimeProc proc, UIntPtr userCtx, uint eventType);

    [DllImport("winmm.dll", SetLastError = true)]
    private static extern uint timeKillEvent(uint uTimerID);
}
