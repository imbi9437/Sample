using Script.Data.General;
using Script.Enemy;
using UnityEngine;

public class BloodMoon : MonsterTraitEffectBase
{
    public override void ApplyTo(Monster monster, Grade grade)
    {
        monster.combatData.attack *= 2;
    }
}
