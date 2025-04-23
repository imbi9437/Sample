using System.Collections.Generic;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string, MonsterBaseData> _monsterBaseData;
        private static Dictionary<string, MonsterVariantData> _monsterVariantData;

        public static MonsterBaseData GetMonsterBase(string id)
        {
            return _monsterBaseData.GetValueOrDefault(id);
        }

        public static MonsterVariantData GetMonsterVariant(string id)
        {
            return _monsterVariantData.GetValueOrDefault(id);
        }
    }
}