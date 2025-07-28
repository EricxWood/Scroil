using System;

public static class MathUtils
{
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
}
