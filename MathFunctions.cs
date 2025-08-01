using System;
using System.CodeDom;

public class MathUtils
{
    public MathUtils(Config cfg)
    {
        this.cfg = cfg;
        this.number_of_step = cfg.animation_duration / Config.render_interval;
        // this.number_of_step_acceleration = cfg.acceleration_duration / Config.render_interval;
        // this.number_of_step_deacceleration = cfg.deacceleration_duration / Config.render_interval;
        this.LUTFor_Remaped_Sigmoid = new double[number_of_step];
    }

    public static double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x));
    }

    public static double Remaped_Sigmoid(double progress_ratio)
    {
        double x_length = Config.Remaped_Sigmoid_x_end - Config.Remaped_Sigmoid_x_begin;

        double x = Config.Remaped_Sigmoid_x_begin + (x_length * progress_ratio);

        return Sigmoid(x);

    }

    public static double Remaped_Sigmoid_xGreaterThan0(double progress_ratio)
    {
        double x_length = Config.Remaped_Sigmoid_x_end - 0;

        double x = x_length * progress_ratio;

        return Sigmoid(x);
    }

    private int number_of_step;
    // private int number_of_step_acceleration;
    // private int number_of_step_deacceleration;
    private double[] LUTFor_Remaped_Sigmoid;
    private Config cfg;
    public int real_total_life_ms = 0;

    public void Generate_LUTFor_Remaped_Sigmoid()
    {
        // private LinkedList<double> LUTFor_Remaped_Sigmoid_temp;
        int index = 0;
        double Remaped_Sigmoid_value_temp = 0.0;

        for (int i = 0; i < this.number_of_step; i++)
        {
            double life_percentage_passed = (double)i / (double)cfg.animation_duration;
            Remaped_Sigmoid_value_temp = Remaped_Sigmoid(life_percentage_passed) * cfg.step_size;

            int drop = 1; // default: keep every value
            if (Remaped_Sigmoid_value_temp < Config.drop_value_level0) drop = 5;
            else if (Remaped_Sigmoid_value_temp < Config.drop_value_level1) drop = 4;
            else if (Remaped_Sigmoid_value_temp < Config.drop_value_level2) drop = 3;
            else if (Remaped_Sigmoid_value_temp < Config.drop_value_level3) drop = 2;

            // if (cfg.step_size - Remaped_Sigmoid_value_temp < Config.drop_value_level0) drop = 5;
            // else if (cfg.step_size - Remaped_Sigmoid_value_temp < Config.drop_value_level1) drop = 4;
            // else if (cfg.step_size - Remaped_Sigmoid_value_temp < Config.drop_value_level2) drop = 3;
            // else if (cfg.step_size - Remaped_Sigmoid_value_temp < Config.drop_value_level3) drop = 2;

            if (i % drop == 0)
            {
                LUTFor_Remaped_Sigmoid[index] = Remaped_Sigmoid_value_temp;
                index++;
            }

            if (i == this.number_of_step - 1)
            {
                real_total_life_ms = index * Config.render_interval;
                for (int j = index; j < this.number_of_step; j++)
                {
                    LUTFor_Remaped_Sigmoid[j] = LUTFor_Remaped_Sigmoid[index - 1];
                }
            }
        }

        // foreach (double item in LUTFor_Remaped_Sigmoid)
        // {
        //     Console.WriteLine(item);
        // }
    }

    // public void Generate_LUTFor_Remaped_Sigmoid()
    // {
    //     // When t < 0, S = ct^2 + dt; c = 0.5 * ((normal_speed - v0)/ cfg.acceleration_duration), d = ((2 * -Config.Remaped_Sigmoid_x_begin) / cfg.acceleration_duration) - normal_speed
    //     // Remember: v0 = d; normal_speed = Config.Remaped_Sigmoid_x_end / cfg.deacceleration_duration
    //     // When t >= 0, call Remaped_Sigmoid() instead

    //     double normal_speed = Config.Remaped_Sigmoid_x_end / cfg.deacceleration_duration;
    //     double d = (2 * -Config.Remaped_Sigmoid_x_begin / cfg.acceleration_duration) - normal_speed;
    //     double c = 0.5 * ((normal_speed - d) / cfg.acceleration_duration);
    //     int index = 0;

    //     for (int i = -this.number_of_step_acceleration; i < 0; i++)
    //     {
    //         double x = c * i * i + d * i;
    //         LUTFor_Remaped_Sigmoid[index] = Sigmoid(x) * cfg.step_size;
    //         // System.Console.WriteLine(LUTFor_Remaped_Sigmoid[index]);
    //         index++;
    //     }

    //     for (int i = 0; i < this.number_of_step_deacceleration; i++)
    //     {
    //         double life_percentage_passed = (double)i / (double)cfg.deacceleration_duration;
    //         LUTFor_Remaped_Sigmoid[index] = Remaped_Sigmoid_xGreaterThan0(life_percentage_passed) * cfg.step_size;
    //         // System.Console.WriteLine(LUTFor_Remaped_Sigmoid[index]);
    //         index++;
    //     }

    // }

    public double LookUp_Remaped_Sigmoid(int id)
    {
        return LUTFor_Remaped_Sigmoid[id];
    }
}
