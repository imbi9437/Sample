using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Data
{
    /// <summary>모험가 직업 데이터</summary>
    [Serializable]
    public class AdventurerJobData
    {
        public string id;
        public string name;
        public CombatData combatBonus;
        public List<string> jobTraitIds;
        public List<string> prevJob;
        public List<string> nextJob;
        public string description;
    }
}