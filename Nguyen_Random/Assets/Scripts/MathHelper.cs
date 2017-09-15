using UnityEngine;

public class MathHelper {
    /// <summary>
    /// Calculating the Gaussian Distribution
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="stdDev"></param>
    /// <returns></returns>
    public static float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);

        float val2 = Random.Range(0f, 1f);

        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

    /// <summary>
    /// Calculating the absolute Gaussian Distribution
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="stdDev"></param>
    /// <returns></returns>
    public static float AbsGaussian(float mean, float stdDev)
    {
        return Mathf.Abs(Gaussian(mean, stdDev));
    }

}
