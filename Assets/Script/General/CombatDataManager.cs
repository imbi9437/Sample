using System.Collections.Generic;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string, CombatTemplateData> _combatTemplateData;

        public static CombatData GetCombat(string id)
        {
            if (!_combatTemplateData.TryGetValue(id, out var data)) return null;
            
            CombatData combat = data.combatData.CopyTo() * Random.Range(data.minRatio, data.maxRatio);
            return combat;
        }
    }
}