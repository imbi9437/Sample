using Script.Enemy;
using UnityEngine;

public abstract class MonsterTraitEffectBase : IMonsterTraitEffect
{
    public virtual void ApplyTo(Monster monster, TraitGrade grade) { }
    public virtual void OnPlacingDungeon(TraitGrade grade) { }

    public virtual void OnDungeonCleared(TraitGrade grade) { }

    public virtual void OnRewardCalculated(TraitGrade grade) { }

    public virtual void OnCombat(TraitGrade grade) { }
}
