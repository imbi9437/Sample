using Script.Data.General;
using Script.Enemy;
using UnityEngine;

public abstract class DungeonTraitEffectBase : IDungeonTraitEffect
{
    public virtual void ApplyTo(Dungeon dungeon, Grade grade) { }

    public virtual void OnDungeonDiscovered(Grade grade) { }
    
    public virtual void OnDungeonOverflowed(Grade grade) { }

    public virtual void OnAdventureAssigned(Grade grade) { }

    public virtual void OnCombatCalculated(Grade grade) { }

    public virtual void OnCombatFailed(Grade grade) { }
    
    public virtual void OnCombatSucceeded(Grade grade) { }

    public virtual void OnRewardCalculated(Grade grade) { }
}