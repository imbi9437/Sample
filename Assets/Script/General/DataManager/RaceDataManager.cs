using System.Collections.Generic;
using System.Linq;
using Script.Data;
using Script.Data.General;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<Race, RaceData> _raceData;

        private static void InitializeRaceData()
        {
            _raceData = new Dictionary<Race, RaceData>();
            ReadData<List<RaceData>>("RaceDB", list =>
            {
                foreach (var data in list)
                {
                    _raceData.TryAdd(data.race, data);
                }
            });
        }

        public static RaceData GetRaceData(Race race) => _raceData[race];
    }
}