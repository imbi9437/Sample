using System;
using System.Collections.Generic;
using Script.Data.General;
using UnityEngine;

namespace Script.Data
{
    /// <summary>몬스터 기본 정보</summary>
    [Serializable]
    public class MonsterBaseData
    {
        public string baseId;
        public string name;
        public Race race;
        public List<string> defaultTraitIds;
        public string description;
    }
}