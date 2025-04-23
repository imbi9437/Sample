using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Data.Enemy
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
    }

    public enum DungeonEnv
    {
        Plane,
        Volcano,
        Swamp,
    }

    public enum Size
    {
        Village,
        Domain,
        Nation,
        Continent,
        World
    }

    public enum DungeonType
    {
        
    }
    
    [Serializable]
    public class DungeonData
    {
        [Header("데이터")]
        public string Name;
        public string ID;
        
        [Space(10),Header("던전 정보")]
        public bool IsDiscovered;
        public bool IsElite;
        public int EliteCount;
        public int EliteTriggerFailCount;
        public int AttemptCount;
        public Difficulty Difficulty;
        public Size Size;
        public TimeSpan RemainingTime;  // todo : Change => for Calculate Time
        
        [Space(10),Header("던전 외 정보")]
        //public List<MonsterData> Monsters;
        public List<TrapData> Traps;
        public List<DungeonTraitData> Traits;
        public List<ItemData> Rewards;  // todo : Change class to Reward => for item Count And NoneItem(ex: Gold, Information)
        
        [Space(10),Header("던전 타입")]
        public DungeonType Type;
        public List<TriggerCondition> TriggerConditions;
    }
}