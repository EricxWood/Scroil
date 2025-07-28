using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

class Mouse_Zdata_Intercept
{
    public static object lock_for_target = new object();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll")]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public uint mouseData;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    private const int WH_MOUSE_LL = 14;
    private const int WM_MOUSEWHEEL = 0x020A;

    private static IntPtr hookId = IntPtr.Zero; 
    public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    public static LowLevelMouseProc proc = HookCallback;

    public static int target;

    const uint LLMHF_INJECTED = 0x00000001;


    public static void SetHook(LowLevelMouseProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule? curModule = curProcess.MainModule)
        {
            string? moduleName = curModule?.ModuleName;
            if (moduleName == null)
            {
                throw new InvalidOperationException("Process MainModule is null.");
            }
            hookId = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(moduleName), 0);
        }
    }


    public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            if (wParam == (IntPtr)WM_MOUSEWHEEL)
            {
                MSLLHOOKSTRUCT hookStruct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);

                // Only block hardware events, let injected events pass through
                if ((hookStruct.flags & LLMHF_INJECTED) == 0)
                {
                    int delta = (short)((hookStruct.mouseData >> 16) & 0xffff);
                    lock (lock_for_target)
                    {
                        target += delta;
                    }
                    Console.WriteLine($"[INTERCEPTED] Mouse wheel delta: {delta}");
                    return (IntPtr)1; // Block hardware event
                }
                // else: injected event, do NOT block!
            }
        }
        return CallNextHookEx(hookId, nCode, wParam, lParam); // Pass injected events through
    }


    public static void ReleaseHook()
    {
        if (hookId != IntPtr.Zero)
        {
            UnhookWindowsHookEx(hookId);
            hookId = IntPtr.Zero;
        }
    }
}

