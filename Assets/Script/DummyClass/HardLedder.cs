using Script.Enemy;
using UnityEngine;

public class HardLedder : MonsterTraitEffectBase
{
    public override void ApplyTo(Monster monster, TraitGrade grade)
    {
        monster.combatData.hp *= 2;
    }
}
