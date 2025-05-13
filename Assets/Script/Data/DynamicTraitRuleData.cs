using System;
using System.Collections.Generic;
using Script.Data.General;
using Script.Enum;
using UnityEngine;

namespace Script.Data
{
    /// <summary>특성 생성 규칙 데이터</summary>
    [Serializable]
    public class DynamicTraitRuleData
    {
        public string traitId;
        public List<Grade> requireGrades;
        public List<Race> requireRace;
        public List<Element> requireElement;
        public List<MonsterType> requireMonsterType;
        public List<string> requireAdventurerJob;
        public string requireHp;
        public string requireAtk;
        public string requireDef;
        public List<string> requireTraitIds;
        public List<string> conflictTraitIds;
        public Dictionary<Grade, int> GradeWeight;
        public Dictionary<Grade, Dictionary<Grade, int>> ApplyTraitGradeWeight;
        public string description;
    }
}