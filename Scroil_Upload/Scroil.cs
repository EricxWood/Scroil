// Main entry class

using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        Mouse_Zdata_Intercept.SetHook(Mouse_Zdata_Intercept.proc);
        Console.WriteLine("Mouse wheel hook started, mouse z-data now becomes invisiable to other apps");

        // int count = 0;
        Stopwatch sw = Stopwatch.StartNew();

        using var timer = new MultimediaTimer(Config.render_interval);

        timer.OnTick += () =>
        {
            // Debug only, for high-precision clock
            // count++;
            // if (count == 1000)
            // {
            //     sw.Stop();
            //     Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds + " ms");
            //     // Optionally reset for next 1000 cycles
            //     sw.Restart();
            //     count = 0;
            // }

            SmoothScroller.Update(ref Mouse_Zdata_Intercept.target);
        };

        timer.Start();

        Application.Run();
        Mouse_Zdata_Intercept.ReleaseHook();
    }

    // static void Main()
    // {
    //     int animation_duration = 360;
    //     int remaining_life_ms = 311;
    //     double value = (double)(animation_duration - remaining_life_ms) / (double)animation_duration;
    //     Console.WriteLine(value);  // Output: ~0.88
    // }
}

class Config
{
    public static int render_interval = 1; // 1 ms
    public static int delta = 120; // 1 tick on mouse wheel, abs(delta) += 120
    public static double Remaped_Sigmoid_x_begin = -4;
    public static double Remaped_Sigmoid_x_end = 4;
    public static int step_size = 120; // 120 px
    public static int animation_duration = 360; // 360 ms
    public static double abs_render_scroll_amount_min = 1.2;
    public static double abs_render_scroll_amount_max = 5.0;
    public static double render_scroll_amount_gain_min = 1.0;
    public static double render_scroll_amount_gain_max = 7.0;
}