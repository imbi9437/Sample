using System.Collections.Generic;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string, MonsterVariantData> _monsterVariantData;

        private static void InitializeMonsterVariantData()
        {
            _monsterVariantData = new Dictionary<string, MonsterVariantData>();
            ReadData<List<MonsterVariantData>>("MonsterVariantData", list =>
            {
                foreach (var data in list)
                {
                    _monsterVariantData.TryAdd(data.variantId, data);
                }
            });
        }

        public static MonsterVariantData GetMonsterVariantData(string id) => _monsterVariantData[id];
    }
}