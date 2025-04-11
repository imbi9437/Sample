using System;
using UnityEngine;
using Random = UnityEngine.Random;

public static class EnumUtil<T> where T : Enum
{
    private static readonly T[] Value = (T[])Enum.GetValues(typeof(T));

    public static T GetRandom()
    {
        return Value[Random.Range(0, Value.Length)];
    }

    public static T GetRandom(int yIndex)
    {
        if (yIndex >= Value.Length) yIndex = Value.Length;

        return Value[Random.Range(0, yIndex)];
    }
}
