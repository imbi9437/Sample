using System.Collections.Generic;
using System.Linq;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string, DynamicTraitRuleData> _dynamicTraitRuleData;
        
        private static void InitializeTraitRuleData()
        {
            _dynamicTraitRuleData = new Dictionary<string, DynamicTraitRuleData>();
            ReadData<List<DynamicTraitRuleData>>("DynamicTraitRuleDB", list =>
            {
                foreach (var data in list)
                {
                    _dynamicTraitRuleData.TryAdd(data.traitId, data);
                }
            });
        }
        
        public static DynamicTraitRuleData GetRuleData(string traitId) => _dynamicTraitRuleData[traitId];
    }
}