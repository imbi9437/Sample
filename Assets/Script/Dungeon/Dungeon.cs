using System;
using System.Collections.Generic;
using Script.Data.Enemy;
using UnityEngine;

namespace Script.Enemy
{
    [Serializable]
    public class Dungeon
    {
        [Header("데이터")]
        public string name;
        public string id;
        
        [Space(10),Header("던전 정보")]
        public bool isDiscovered;
        public bool isElite;
        public int eliteCount;
        public int eliteTriggerFailCount;
        public int attemptCount;
        public Difficulty difficulty;
        public DungeonEnv environment;
        public Size size;
        public TimeSpan RemainingTime;  // todo : Change => for Calculate Time
        public Vector2Int pos;
        
        [Space(10),Header("던전 외 정보")]
        public List<MonsterData> monsters;
        public List<TrapData> traps;
        public List<DungeonTraitData> traits;
        public List<ItemData> rewards;  // todo : Change class to Reward => for item Count And NoneItem(ex: Gold, Information)
        
        [Space(10),Header("던전 타입")]
        public DungeonType type;
        public List<TriggerCondition> triggerConditions;
    }
}
