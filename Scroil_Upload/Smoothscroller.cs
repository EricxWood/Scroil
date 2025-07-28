using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;


class SmoothScroller
{
    [StructLayout(LayoutKind.Sequential)]
    private struct INPUT
    {
        public uint type;
        public InputUnion u;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct InputUnion
    {
        [FieldOffset(0)] public MOUSEINPUT mi;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    private const uint INPUT_MOUSE = 0;
    private const uint MOUSEEVENTF_WHEEL = 0x0800;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    private static void Render(int scrollAmount)
    {
        INPUT[] inputs = new INPUT[1];
        inputs[0].type = INPUT_MOUSE;
        inputs[0].u.mi = new MOUSEINPUT
        {
            dx = 0,
            dy = 0,
            mouseData = (uint)scrollAmount,
            dwFlags = MOUSEEVENTF_WHEEL,
            time = 0,
            dwExtraInfo = IntPtr.Zero
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    private static double mapScrollAmountToScrollGain(double render_scroll_amount)
    {
        double abs_render_scroll_amount = Math.Abs(render_scroll_amount);

        if (abs_render_scroll_amount <= Config.abs_render_scroll_amount_min)
            return Config.render_scroll_amount_gain_min;

        if (abs_render_scroll_amount >= Config.abs_render_scroll_amount_max)
            return Config.render_scroll_amount_gain_max;

        return Config.render_scroll_amount_gain_min + ((abs_render_scroll_amount - Config.abs_render_scroll_amount_min) * (Config.render_scroll_amount_gain_max / Config.abs_render_scroll_amount_max - Config.abs_render_scroll_amount_min));
    }



    public static double position = 0;
    public static double velocity = 0;
    private static int step_size = Config.step_size;
    private static int animation_duration = Config.animation_duration;
    private static LinkedList<ScrollPowerSystem> scrollPowerUnits = new LinkedList<ScrollPowerSystem>();
    static double accumulator = 0;

    public static void Update(ref int target)
    {
        if (target != 0) // Detected mouse z-axis input
        {

            int number_of_step = 0;
            int direction_of_delta = 1;
            number_of_step = Math.Abs(target / Config.delta);
            if (target > 0)
            {
                direction_of_delta = 1;
                target = 0; // Reset target
            }
            else
            {
                direction_of_delta = -1;
                target = 0; // Reset target
            }

            for (int i = 0; i < number_of_step; i++)
            {
                var scrollPowerUnit = new ScrollPowerSystem();
                scrollPowerUnit.remaining_life_ms = animation_duration;
                scrollPowerUnit.direction = direction_of_delta;
                scrollPowerUnits.AddLast(scrollPowerUnit);
            }
        }

        if (scrollPowerUnits.Count != 0)
        {
            // Calculate the scroll amount to be rendered, then render
            ScrollPowerSystem.total_position_now = 0.0;
            foreach (ScrollPowerSystem scrollPowerUnit in scrollPowerUnits)
            {
                double life_percentage_passed = (double)1 - (scrollPowerUnit.remaining_life_ms / (double)animation_duration);
                double unit_scroll_amount = (double)scrollPowerUnit.direction * MathUtils.Remaped_Sigmoid(life_percentage_passed) * (double)step_size; // unit_scroll_amount = scroll_dir * Remaped_Sigmoid(life_percentage_passed) * step_size
                ScrollPowerSystem.total_position_now += unit_scroll_amount;
            }

            double render_scroll_amount = ScrollPowerSystem.total_position_now - ScrollPowerSystem.total_position_last; // The scroll amount to be render in this cycle
            double scroll_gain = mapScrollAmountToScrollGain(render_scroll_amount);
            accumulator  += render_scroll_amount * scroll_gain;

            if (Math.Abs(accumulator) >= 1)
            {
                int delta_px = (int)accumulator;
                Render((int)delta_px);
                accumulator -= delta_px; // remove the sent part
            }

            ScrollPowerSystem.total_position_last = ScrollPowerSystem.total_position_now;

            // Update LinkedList<ScrollPowerSystem> scrollPowerUnits
            var node = scrollPowerUnits.First;
            while (node != null)
            {
                var next = node.Next; // Save next node, since current might be removed

                node.Value.remaining_life_ms--;
                if (node.Value.remaining_life_ms == 0)
                {
                    ScrollPowerSystem.total_position_last -= node.Value.direction* step_size;
                    scrollPowerUnits.Remove(node);
                    node = null;
                }

                node = next;
            }

            if (scrollPowerUnits.Count == 0)
            {
                ScrollPowerSystem.total_position_last = 0;
                ScrollPowerSystem.total_position_now = 0;
                accumulator = 0;
            }
        }



    }
}

class ScrollPowerSystem
{
    public static double total_position_last = 0;
    public static double total_position_now = 0;
    public int remaining_life_ms = 0;
    public int direction = 1;
}

