using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public static partial class DataManager
    {
        public static void Initialize()
        {
            InitializeAdventurerJobData();
            InitializeCombatTemplateData();
            InitializeTraitRuleData();
            InitializeElementData();
            InitializeMonsterBaseData();
            InitializeMonsterVariantData();
            InitializeRaceData();
            InitializeTraitData();
        }

        private static void ReadData<T>(string fileName, Action<T> callback)
        {
            string path = Path.Combine(Application.streamingAssetsPath, "DataBase", $"{fileName}.json");
            
            RestAPI.Get(path, RestAPI.ServerType.Out).OnComplete += s =>
            {
                var data = JsonConvert.DeserializeObject<T>(s);

                callback?.Invoke(data);
            };
        }
    }
}