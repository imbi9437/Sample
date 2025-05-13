using System.Collections.Generic;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string, MonsterBaseData> _monsterBaseData;

        private static void InitializeMonsterBaseData()
        {
            _monsterBaseData = new Dictionary<string, MonsterBaseData>();
            ReadData<List<MonsterBaseData>>("MonsterBaseDB", list =>
            {
                foreach (var data in list)
                {
                    _monsterBaseData.TryAdd(data.baseId, data);
                }
            });
        }

        public static MonsterBaseData GetMonsterBaseData(string id) => _monsterBaseData[id];
    }
}