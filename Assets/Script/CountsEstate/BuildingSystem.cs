using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoSingleton<BuildingSystem>
{
    private const int DefaultHeight = 5;
    private const int DefaultWidth = 5;

    public Dictionary<Vector2Int, bool> Map;
    public Vector2Int GridSize;
    public BuildingData data;
    public Vector2Int StartPos;

    private void Start()
    {
        Map = new Dictionary<Vector2Int, bool>();
        GridSize = new Vector2Int(DefaultWidth, DefaultHeight);
        for (int i = 0; i < GridSize.x; i++)
        {
            for (int j = 0; j < GridSize.y; j++)
            {
                Map.TryAdd(new Vector2Int(i,j),false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaceBuilding(StartPos, data);
        }
    }

    private bool IsInsideGrid(Vector2Int pos)
    {
        bool temp = pos.x >= 0 && pos.y >= 0 && pos.x < GridSize.x && pos.y < GridSize.y;
        return temp;
    }

    private bool CanPlaceBuilding(Vector2Int startPos, BuildingData data)
    {
        for (int x = 0; x < data.Width; x++)
        {
            for (int y = 0; y < data.Height; y++)
            {
                var asd = data.GetCell(x, y);
                
                if (asd == false) continue;
                
                var pos = startPos + new Vector2Int(x, y);
                if (IsInsideGrid(pos) == false && Map[pos] == false)
                    return false;
            }
        }
        
        return true;
    }

    private bool PlaceBuilding(Vector2Int startPos, BuildingData data)
    {
        if (CanPlaceBuilding(startPos, data) == false) return false;
        
        for (int x = 0; x < data.Width; x++)
        {
            for (int y = 0; y < data.Height; y++)
            {
                if (data.GetCell(x,y) == false) continue;
                
                var pos = startPos + new Vector2Int(x, y);
                Map[pos] = true;
            }
        }

        return true;
    }

    #region DebugLogic
    
    private void OnDrawGizmos()
    {
        if (Map == null) return;
        
        Gizmos.color = new Color(0, 1, 0, 0.1f);

        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                var pos = new Vector2Int(x, y);
                Gizmos.color = Map[pos] ? new Color(1, 0, 0, 0.3f) : new Color(0, 1, 0, 0.3f);
                Gizmos.DrawCube(new Vector3(x,0,y),new Vector3(1,0,1));
            }
        }
        
        Gizmos.color = Color.black;
        for (int i = 0; i < DefaultHeight; i++)
        {
            for (int j = 0; j < DefaultWidth; j++)
            {
                Gizmos.DrawWireCube(new Vector3(j,0,i),new Vector3(1,0,1));
            }
        }
    }
    
    #endregion
}
