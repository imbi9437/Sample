using System.Collections.Generic;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string, CombatTemplateData> _combatTemplateData;

        private static void InitializeCombatTemplateData()
        {
            _combatTemplateData = new Dictionary<string, CombatTemplateData>();
            ReadData<List<CombatTemplateData>>("CombatTemplateDB", list =>
            {
                foreach (var data in list)
                {
                    _combatTemplateData.TryAdd(data.id, data);
                }
            });
        }
        
        public static CombatData GetCombat(string id)
        {
            if (!_combatTemplateData.TryGetValue(id, out var data)) return null;
            
            CombatData combat = data.combatData.CopyTo() * Random.Range(data.minRatio, data.maxRatio);
            return combat;
        }
    }
}