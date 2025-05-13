using System.Collections.Generic;
using System.Linq;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string, TraitData> _traitData;

        private static void InitializeTraitData()
        {
            _traitData = new Dictionary<string, TraitData>();
            ReadData<List<TraitData>>("TraitDB", list =>
            {
                foreach (var data in list)
                {
                    _traitData.TryAdd(data.traitId, data);
                }
            });
        }

        public static TraitData GetTraitData(string traitId) => _traitData[traitId];
    }
}