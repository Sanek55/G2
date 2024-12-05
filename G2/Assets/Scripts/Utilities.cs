using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    int[] ResizeArray(int[] source, int newSize)
    {
        int[] newArray = new int[newSize];
        for (int i = 0; i < Mathf.Min(source.Length, newSize); i++)
        {
            newArray[i] = source[i];
        }
        return newArray;
    }
    public SplinePoint[] PointsArrayResize (SplinePoint[] source, int newSize)
    {
        SplinePoint[] newArray = new SplinePoint[newSize];
        for (int i = 0; i < Mathf.Min(source.Length, newSize); i++)
        {
            newArray[i] = source[i];
        }
        return newArray;
    }
}

