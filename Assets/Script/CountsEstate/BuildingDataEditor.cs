using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BuildingData))]
public class BuildingDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BuildingData data = (BuildingData)target;

        EditorGUILayout.LabelField("Item ID");
        data.ItemID = EditorGUILayout.TextField(data.ItemID);
        
        data.Width = EditorGUILayout.IntField("Width", data.Width);
        data.Height = EditorGUILayout.IntField("Height", data.Height);

        data.Icon = (Sprite)EditorGUILayout.ObjectField("Icon", data.Icon, typeof(Sprite), false);
        
        // 마스크 크기 변경 시 재초기화
        if (data.flatMask.Count != data.Width * data.Height)
        {
            data.flatMask = new List<bool>(new bool[data.Width * data.Height]);
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Shape Mask");

        for (int y = 0; y < data.Height; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < data.Width; x++)
            {
                bool current = data.GetCell(x, y);
                bool toggled = GUILayout.Toggle(current, "", "Button", GUILayout.Width(20), GUILayout.Height(20));
                if (current != toggled)
                {
                    Undo.RecordObject(data, "Toggle Cell");
                    data.SetCell(x, y, toggled);
                    EditorUtility.SetDirty(data);
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Clear Mask"))
        {
            Undo.RecordObject(data, "Clear Mask");
            for (int i = 0; i < data.flatMask.Count; i++)
                data.flatMask[i] = false;
            EditorUtility.SetDirty(data);
        }
    }
}
