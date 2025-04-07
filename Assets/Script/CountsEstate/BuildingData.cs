using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Scriptable Objects/BuildingData")]
public class BuildingData : ScriptableObject
{
    public string ItemID;
    public Sprite Icon;
    public int Width = 1;
    public int Height = 1;

    [HideInInspector]
    public List<bool> flatMask = new();
    
    public bool[,] GetMask()
    {
        bool[,] result = new bool[Width, Height];
        for (int x = 0; x < Width; x++)
        for (int y = 0; y < Height; y++)
            result[x, y] = flatMask[y * Width + x];
        return result;
    }

    public void SetMask(bool[,] mask)
    {
        Width = mask.GetLength(0);
        Height = mask.GetLength(1);
        flatMask = new List<bool>(Width * Height);
        for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
            flatMask.Add(mask[x, y]);
    }

    public bool GetCell(int x, int y)
    {
        return flatMask[y * Width + x];
    }

    public void SetCell(int x, int y, bool value)
    {
        flatMask[y * Width + x] = value;
    }
}
