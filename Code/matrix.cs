using System;

public class FPSAnalyzer
{
    private readonly int[] fpsBuffer;
    private int index = 0;
    private int count = 0;

    public FPSAnalyzer(int bufferSize)
    {
        fpsBuffer = new int[bufferSize];
    }

    // Call this every second with the current FPS
    public void AddSample(int fps)
    {
        fpsBuffer[index] = fps;
        index = (index + 1) % fpsBuffer.Length;
        if (count < fpsBuffer.Length)
            count++;
    }

    public int Count()
    {
        return count;
    }

    // Returns standard deviation of the collected FPS values
    public double FPSstdDev()
    {
        if (count == 0)
            return 0;

        double sum = 0;
        for (int i = 0; i < count; i++)
            sum += fpsBuffer[i];

        double mean = sum / count;

        double variance = 0;
        for (int i = 0; i < count; i++)
            variance += (fpsBuffer[i] - mean) * (fpsBuffer[i] - mean);

        variance /= count; // for population stdDev
        return Math.Sqrt(variance);
    }
}
