using System;
using System.Collections.Generic;
using Script.Data.General;
using UnityEngine;

namespace Script.Data
{
    /// <summary>Race 설명 및 관련 특성 및 UI용 데이터</summary>
    [Serializable]
    public class RaceData
    {
        public Race race;
        public List<string> traitIds;
        public CombatData combatDataUI;
        public string description;
    }
}