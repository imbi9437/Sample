using System.Collections.Generic;
using System.Linq;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<string,AdventurerJobData> _adventurerJobData;

        private static void InitializeAdventurerJobData()
        {
            _adventurerJobData = new Dictionary<string, AdventurerJobData>();
            ReadData<List<AdventurerJobData>>("AdventurerJobDB", list =>
            {
                foreach (var data in list)
                {
                    _adventurerJobData.TryAdd(data.id, data);
                }
            });
        }

        public static AdventurerJobData GetAdventurerJobData(string id) => _adventurerJobData[id];
    }
}