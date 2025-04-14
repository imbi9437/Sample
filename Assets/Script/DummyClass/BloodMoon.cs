using Script.Enemy;
using UnityEngine;

public class BloodMoon : MonsterTraitEffectBase
{
    public override void ApplyTo(Monster monster, TraitGrade grade)
    {
        monster.combatData.attack *= 2;
    }
}
