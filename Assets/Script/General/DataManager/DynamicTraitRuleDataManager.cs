using System.Collections.Generic;
using System.Linq;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        public static List<DynamicTraitRuleData> raceRuleData;
        public static List<DynamicTraitRuleData> elementRuleData;
        public static List<DynamicTraitRuleData> adventurerRuleData;
        public static List<DynamicTraitRuleData> monsterTypeRuleData;
        public static List<DynamicTraitRuleData> gradeRuleData;
        public static List<DynamicTraitRuleData> dynamicRuleData;

        public static DynamicTraitRuleData GetRaceRuleData(string traitId) =>
            raceRuleData.FirstOrDefault(s => s.traitId == traitId);
    }
}