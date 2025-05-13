using System.Collections.Generic;
using System.Linq;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        public static List<TraitData> raceTraitData;
        public static List<TraitData> elementTraitData;
        public static List<TraitData> adventurerJobTraitData;
        public static List<TraitData> monsterTypeTraitData;
        public static List<TraitData> gradeTraitData;
        public static List<TraitData> dynamicTraitData;

        public static TraitData GetRaceTrait(string traitId) => raceTraitData.FirstOrDefault(s => s.traitId == traitId);
    }
}