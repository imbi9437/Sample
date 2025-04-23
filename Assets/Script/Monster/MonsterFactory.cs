using System.Collections.Generic;
using Script.Data;
using Script.Generic.Manager;
using UnityEngine;

namespace Script.Enemy
{
    public static class MonsterFactory
    {
        public static Monster Create(MonsterVariantData data)
        {
            //특성 계산

            Monster monster = new Monster
            {
                monsterData = data,
                combat = DataManager.GetCombat(data.combatId)
            };

            //기본 특성
            //monster.traitData.AddRange(data.baseTraits);
            
            foreach (var trait in monster.traits)
            {
                var function = TraitEffectSystem.GetEffect(trait.traitData.traitId);
                var context = new MonsterTraitContext();
                
                function.ApplyTo(context);
            }
            
            return monster;
        }
    }
}