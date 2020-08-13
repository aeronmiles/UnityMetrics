using System;
using Unity.Mathematics;


public static class MetricExt
{
    public static float[] Errors(this float[] values, float referenceValue)
    {
        int l = values.Length;
        float[] errors = new float[l];

        for (int i = 0; i < l; i++)
            errors[i] = math.distance(values[i], referenceValue);

        return errors;
    }

    public static float Mean(this float[] floats)
    {
        float m = 0f;
        int l = floats.Length;
        for (int i = 0; i < l; i++)
        {
            m += floats[i];
        }

        return m / l;
    }


    public static float Median(this float[] floats)
    {
        //Framework 2.0 version of this method. there is an easier way in F4        
        if (floats == null || floats.Length == 0)
            throw new System.Exception("Median of empty array not defined.");

        //make sure the list is sorted, but use a new array
        float[] sortedPNumbers = (float[])floats.Clone();
        Array.Sort(sortedPNumbers);

        //get the median
        int size = sortedPNumbers.Length;
        int mid = size / 2;
        float median = (size % 2 != 0) ? (float)sortedPNumbers[mid] : ((float)sortedPNumbers[mid] + (float)sortedPNumbers[mid - 1]) / 2;

        return median;
    }

    public static float Variance(this float[] floats)
    {
        float min = float.MaxValue;
        float max = float.MinValue;

        int l = floats.Length;
        for (int i = 0; i < l; i++)
        {
            min = math.min(min, floats[i]);
            max = math.max(max, floats[i]);
        }

        return math.abs(max - min);
    }

    public static MeanMedianVariance ToMeanMedianVariance(this float[] floats)
    {
        MeanMedianVariance mmv = new MeanMedianVariance();

        mmv.mean = floats.Mean();
        mmv.median = floats.Median();
        mmv.variance = floats.Variance();

        return mmv;
    }

    public static float2 Mean(this float2[] vs)
    {
        float2 average = new float2();
        int l = vs.Length;
        for (int i = 0; i < l; i++)
        {
            average += vs[i];
        }

        return average / l;
    }

    public static long Mean(this long[] vals)
    {
        long m = 0;
        int l = 0;
        for (int i = 0; i < l; i++)
        {
            m += vals[i];
        }

        return m / l;
    }

    public static float MmToMeters(this float f) => f / 1000f;

}