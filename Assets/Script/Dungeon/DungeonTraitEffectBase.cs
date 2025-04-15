using Script.Enemy;
using UnityEngine;

public abstract class DungeonTraitEffectBase : IDungeonTraitEffect
{
    public virtual void ApplyTo(Dungeon dungeon, TraitGrade grade) { }

    public virtual void OnDungeonDiscovered(TraitGrade grade) { }
    
    public virtual void OnDungeonOverflowed(TraitGrade grade) { }

    public virtual void OnAdventureAssigned(TraitGrade grade) { }

    public virtual void OnCombatCalculated(TraitGrade grade) { }

    public virtual void OnCombatFailed(TraitGrade grade) { }
    
    public virtual void OnCombatSucceeded(TraitGrade grade) { }

    public virtual void OnRewardCalculated(TraitGrade grade) { }
}