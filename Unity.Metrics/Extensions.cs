using System;
using Unity.Mathematics;
using UnityEngine;

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

    public static float Min(this float[] floats)
    {
        float m = float.MaxValue;
        int l = floats.Length;
        for (int i = 0; i < l; i++)
        {
            m = math.min(floats[i], m);
        }

        return m;
    }

    public static float Max(this float[] floats)
    {
        float m = float.MinValue;
        int l = floats.Length;
        for (int i = 0; i < l; i++)
        {
            m = math.max(floats[i], m);
        }

        return m;
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

    public static float Squared(this float f) => math.sqrt(f);

    public static float Variance(this float[] floats)
    {
        if (floats.Length > 1)
        {
            float mean = floats.Mean();
            float sumOfSquares = 0.0f;
            foreach (float num in floats)
            {
                sumOfSquares += math.pow((num - mean), 2.0f);
            }

            return sumOfSquares / (float)(floats.Length);
        }
        else { return 0f; }
    }


    public static MeanMedianVarMinMax ToMeanMedianVarMinMax(this float[] floats)
    {
        MeanMedianVarMinMax mmv = new MeanMedianVarMinMax();

        mmv.mean = floats.Mean();
        mmv.median = floats.Median();
        mmv.variance = floats.Variance();
        mmv.min = floats.Min();
        mmv.max = floats.Max();

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

    public static Vector2 Mean(this Vector2[] vs)
    {
        Vector2 average = new Vector2();
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
    public static float MetersToMMs(this float f) => f * 1000f;

}
