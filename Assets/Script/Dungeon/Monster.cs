using System;
using System.Collections.Generic;
using Script.Data.Enemy;
using UnityEngine;

namespace Script.Enemy
{
    [Serializable]
    public class Monster
    {
        public MonsterData monsterData;
        public List<MonsterTrait> traitData;
        public int count;   //던전에 존재하는 몬스터 수

        public CombatData combatData;
    }
}