using System;
using System.Collections.Generic;
using Script.Data;
using Script.Trait;

namespace Script.Enemy
{
    [Serializable]
    public class Monster
    {
        public MonsterVariantData monsterData;
        public List<TraitInstance> traits;
        public CombatData combat;
    }
}