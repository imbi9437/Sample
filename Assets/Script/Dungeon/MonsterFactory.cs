using System.Collections.Generic;
using Script.Data.Enemy;
using UnityEngine;

namespace Script.Enemy
{
    public static class MonsterFactory
    {
        public static Monster Create(MonsterData data)
        {
            Monster monster = new Monster()
            {
                monsterData = data,
                count = Random.Range(1,10),
                combatData = data.baseCombatData.CopyTo(),
                traitData = new List<MonsterTrait>(),
            };

            //기본 특성
            monster.traitData.AddRange(data.baseTraits);
            
            //todo : 추가 특성, 기본 특성 중복 시 등급 더 높은걸로 설정
            

            foreach (var trait in monster.traitData)
            {
                var function = MonsterTraitEffectSystem.GetEffect(trait.traitData.id);
                function.ApplyTo(monster,trait.grade);
            }
            
            return monster;
        }
    }
}