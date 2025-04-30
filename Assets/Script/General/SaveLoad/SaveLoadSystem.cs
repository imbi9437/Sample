using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Script.Generic
{
    public static partial class SaveLoadSystem
    {
        public enum PathType
        {
            Default,
            Resource,
            StreamingAsset,
            Editor,
        }

        private static readonly Dictionary<PathType, string> FolderPath;

        static SaveLoadSystem()
        {
            FolderPath = new Dictionary<PathType, string>();
            FolderPath.TryAdd(PathType.Default, Application.persistentDataPath);
            FolderPath.TryAdd(PathType.Resource, Path.Combine(Application.dataPath, "Resources"));
            FolderPath.TryAdd(PathType.StreamingAsset, Application.streamingAssetsPath);
            FolderPath.TryAdd(PathType.Editor, Path.Combine(Application.dataPath, "Editor"));
        }

        public static void SaveData<T>(string folderName, string fileName, T data, PathType type = PathType.Default) =>
            SaveDataAsync(folderName, fileName, data, type).Forget();

        public static void LoadData<T>(string folderName, string fileName, PathType type = PathType.Default) =>
            LoadDataAsync<T>(folderName, fileName, type).Forget();
        
        private static async UniTaskVoid SaveDataAsync<T>(string folderName, string fileName, T data, PathType type = PathType.Default)
        {
            string folderPath = $"{FolderPath[type]}/{folderName}";
            CheckDirectory(folderPath);

            try
            {
                var json = JsonConvert.SerializeObject(data);
                // 암호화 추가 & WriteAllTextAsync byte로 바꾸기
                var path = Path.Combine(folderPath, fileName);

                await File.WriteAllTextAsync(path, json);

                SaveDataArgs<T> args = new SaveDataArgs<T>() { Data = data };
                GetSubscribe<T>().OnCompleteSave?.Invoke(null,args);
            }
            catch (Exception e)
            {
                Debug.LogError($"Save Data Issue : {e}");
            }
        }

        private static async UniTaskVoid LoadDataAsync<T>(string folderName, string fileName, PathType type = PathType.Default)
        {
            string folderPath = $"{FolderPath[type]}/{folderName}";

            try
            {
                var path = Path.Combine(folderPath, fileName);

                if (File.Exists(path))
                {
                    var json = await File.ReadAllTextAsync(path);
                    //복호화 추가 & File.ReadAllTextAsync byte로 바꾸기
                    var data = JsonConvert.DeserializeObject<T>(json);
                    
                    LoadDataArgs<T> args = new LoadDataArgs<T>() { Data = data };
                    GetSubscribe<T>().OnCompleteLoad?.Invoke(null,args);
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Load Data Issue : {e}");
            }
        }

        private static void CheckDirectory(string path)
        {
            if (Directory.Exists(path)) return;
            Directory.CreateDirectory(path);
        }
    }
    public class SaveDataArgs<T> : EventArgs
    {
        public T Data;
    }
    
    public class LoadDataArgs<T> : EventArgs
    {
        public T Data;
    }
}