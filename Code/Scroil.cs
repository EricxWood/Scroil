// Main entry class

using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        Config cfg = new Config();
        MathUtils mu = new MathUtils(cfg);
        mu.Generate_LUTFor_Remaped_Sigmoid();
        Mouse_Zdata_Intercept.SetHook(Mouse_Zdata_Intercept.proc);
        Console.WriteLine("Mouse wheel hook started, mouse z-data now becomes invisiable to other apps");

        // FPSAnalyzer fPSAnalyzer = new FPSAnalyzer(30);

        // int count = 0;
        Stopwatch sw = new Stopwatch();
        Stopwatch sw_perFrame = new Stopwatch();
        int count_frameLoadingTimeOver1000us = 0;
        int count_frameLoadingTimeOver500us = 0;
        int count_frameLoadingTimeOver100us = 0;
        int fps = 0;
        sw.Start();

        using var timer = new MultimediaTimer(Config.render_interval);

        timer.OnTick += () =>
        {
            // Debug only, for high-precision clock

            sw_perFrame.Start();

            SmoothScroller.Update(ref Mouse_Zdata_Intercept.target, mu, cfg);

            sw_perFrame.Stop();
            if (sw_perFrame.Elapsed.TotalMicroseconds > 1000) count_frameLoadingTimeOver1000us++;
            else if (sw_perFrame.Elapsed.TotalMicroseconds > 500) count_frameLoadingTimeOver500us++;
            else if (sw_perFrame.Elapsed.TotalMicroseconds > 100) count_frameLoadingTimeOver100us++;
            sw_perFrame.Reset();

            fps++;

            // Debug only, for high-precision clock

            if (sw.Elapsed.TotalMilliseconds >= 1000)
            {
                // Console.WriteLine("Elapsed time: " + sw.Elapsed.TotalMicroseconds + " us");
                // fPSAnalyzer.AddSample(fps);
                // if (fPSAnalyzer.Count() == 30)
                // {
                //     double stdDev = fPSAnalyzer.FPSstdDev();
                //     System.Console.WriteLine("FPS stability: " + fPSAnalyzer.FPSstdDev());
                // }
                System.Console.WriteLine("Average fps in 1 sec: " + fps + " fps");
                System.Console.WriteLine("Frame generation time over 1000 us: " + (double)count_frameLoadingTimeOver1000us/1000 * 100 + " %");
                System.Console.WriteLine("Frame generation time over 500 us: " + (double)count_frameLoadingTimeOver500us/1000 * 100 + " %");
                System.Console.WriteLine("Frame generation time over 100 us: " + (double)count_frameLoadingTimeOver100us/1000 * 100 + " %\n");
                count_frameLoadingTimeOver1000us = 0;
                count_frameLoadingTimeOver500us = 0;
                count_frameLoadingTimeOver100us = 0;
                fps = 0;
                // sw.Stop();
                sw.Reset();
                sw.Start();
                

            }
        };

        timer.Start();

        Application.Run();
        Mouse_Zdata_Intercept.ReleaseHook();
    }


    // static void Main()
    // {
    //     AppNameReader.Run();
    // }
    
}

public class Config
{
    // App-independent settings
    public static int render_interval = 1; // 1 ms
    public static int delta = 120; // 1 tick on mouse wheel, abs(delta) += 120
    public static double Remaped_Sigmoid_x_begin = -4.8;
    public static double Remaped_Sigmoid_x_end = 4.8;
    public static double abs_render_scroll_amount_min = 0.7;
    public static double abs_render_scroll_amount_max = 6.0;
    public static double render_scroll_amount_gain_min = 1.0;
    public static double render_scroll_amount_gain_max = 7.0;
    public static int ringBuffer_capacity = 512; // MUST BE the power of 2!!! <---!!!Crucial Parameter!!!---> <---Don't touch it, may hurt performance--->
    public static double drop_value_level0 = 2;
    public static double drop_value_level1 = 4;
    public static double drop_value_level2 = 6;
    public static double drop_value_level3 = 12;

    // App-binding settings
    public int step_size = 120; // 120 px
    // public int acceleration_duration = 230; // ms
    // public int deacceleration_duration = 300; // ms
    // public int animation_duration => acceleration_duration + deacceleration_duration; // ms

    public int animation_duration = 500;
}