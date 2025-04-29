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
        private static readonly string DefaultPath;

        static SaveLoadSystem()
        {
            DefaultPath = Application.persistentDataPath;
        }

        public static void SaveData<T>(string folderName, string fileName, T data) =>
            SaveDataAsync(folderName, fileName, data).Forget();

        public static void LoadData<T>(string folderName, string fileName) =>
            LoadDataAsync<T>(folderName, fileName).Forget();
        
        private static async UniTaskVoid SaveDataAsync<T>(string folderName, string fileName, T data)
        {
            string folderPath = $"{DefaultPath}/{folderName}";
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

        private static async UniTaskVoid LoadDataAsync<T>(string folderName, string fileName)
        {
            string folderPath = $"{DefaultPath}/{folderName}";

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