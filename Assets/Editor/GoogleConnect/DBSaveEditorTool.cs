using System;
using System.Collections.Generic;
using System.Reflection;
using Script.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Script.Editor
{
    [Flags]
    public enum DBType
    {
        None = 0,
        AdventureJob = 1 << 0,
        CombatTemplate = 1 << 1,
        DynamicTraitRule = 1 << 2,
        Element = 1 << 3,
        MonsterBase = 1 << 4,
        MonsterVariant = 1 << 5,
        Race = 1 << 6,
        Trait = 1 << 7,
    }
    
    public class DBSaveEditorTool : EditorWindow
    {
        private const string URL =
            "https://script.google.com/macros/s/AKfycbwSRgsqsQpFBSn9nJcFd4m_Dibc7EsufgAl4yVYdN_oDaTizJMiNvYQG16TfgH2ZsApQQ/exec";
        private DBType _selectSheets;

        [MenuItem("Tools/DB 동기화 툴")]
        public static void ShowWindow() => GetWindow<DBSaveEditorTool>("DB 동기화");

        private void OnGUI()
        {
            GUILayout.Label("Google Sheet → Unity Json",EditorStyles.boldLabel);
            EditorGUILayout.Space(10f);
            
            _selectSheets = (DBType)EditorGUILayout.EnumFlagsField("동기화 대상 시트", _selectSheets);

            if (GUILayout.Button("선택된 시트 동기화"))
            {
                foreach (DBType value in System.Enum.GetValues(typeof(DBType)))
                {
                    if (_selectSheets.HasFlag(value) == false || value == DBType.None) continue;
                    
                    SelectType(value);
                }
            }
        }
        
        private void SaveDataBase<T>(string uri, string fileName, string sheetName)
        {
            string url = $"{uri}?file={fileName}&sheet={sheetName}";

            RestAPI.Get(url, RestAPI.ServerType.Out).OnComplete = s =>
            {
                var data = JsonConvert.DeserializeObject<RestAPIClass<T>>(s);

                if (data.success)
                {
                    var db = data.data;
                    SaveLoadSystem.SaveData("DataBase",$"{sheetName}.json",db,SaveLoadSystem.PathType.StreamingAsset);
                }
                else
                {
                    Debug.LogError($"{typeof(T)} \t {data.code} : {data.message}");
                }
            };
        }

        private void SelectType(DBType type)
        {
            string typeName = $"{type.ToString()}Data";
            string sheetName = $"{type.ToString()}DB";

            Type dataType = FineTypeByFullName($"Script.Data.{typeName}");

            if (dataType == null)
            {
                Debug.Log($"해당 타입이 존재하지 않습니다 : {typeName}");
                return;
            }

            Type listType = typeof(List<>).MakeGenericType(dataType);

            MethodInfo method = typeof(DBSaveEditorTool).GetMethod(nameof(SaveDataBase),
                BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo generic = method.MakeGenericMethod(listType);
            generic.Invoke(this, new object[] {URL, type.ToString(),sheetName });
        }

        private Type FineTypeByFullName(string fullName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var type = assembly.GetType(fullName);
                    if (type != null)
                        return type;
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
            
            return null;
        }
    }
}