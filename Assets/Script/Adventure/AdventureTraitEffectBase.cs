using Script.Data.General;
using Script.Trait;
using UnityEngine;

public abstract class AdventureTraitEffectBase : IAdventureTraitEffect
{
    public virtual void ApplyTo(TraitContext context) { }

    public virtual void OnCombatCalculated(Grade grade) { }
}
