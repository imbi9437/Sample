using Script.Data.General;
using Script.Enemy;
using Script.Trait;
using UnityEngine;

public abstract class MonsterTraitEffectBase : IMonsterTraitEffect
{
    public virtual void ApplyTo(TraitContext context) {}
    
    public virtual void OnPlacingDungeon(Grade grade) { }

    public virtual void OnDungeonCleared(Grade grade) { }

    public virtual void OnRewardCalculated(Grade grade) { }

    public virtual void OnCombat(Grade grade) { }
}
