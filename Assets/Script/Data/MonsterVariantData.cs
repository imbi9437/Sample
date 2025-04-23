using System;
using Script.Data.General;
using Script.Enum;
using UnityEngine;

namespace Script.Data
{
    /// <summary>종합 몬스터 정보</summary>
    [Serializable]
    public class MonsterVariantData
    {
        public string variantId;
        public string baseId;
        public string name;
        public MonsterType type;
        public Grade grade;
        public Element element;
        public string modelId;
        public string combatId;
        public string description;
    }
}