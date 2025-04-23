using System;
using Script.Data.General;
using UnityEngine;

namespace Script.Data
{
    /// <summary>기본 스탯 템플릿 데이터</summary>
    [Serializable]
    public class CombatTemplateData
    {
        public string id;
        public Race race;
        public Grade grade;
        public CombatData combatData;
        public float minRatio;
        public float maxRatio;
        public string description;
    }
}