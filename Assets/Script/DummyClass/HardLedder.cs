using Script.Data.General;
using Script.Enemy;
using UnityEngine;

public class HardLedder : MonsterTraitEffectBase
{
    public override void ApplyTo(Monster monster, Grade grade)
    {
        monster.combatData.hp *= 2;
    }
}
