using Script.Data.General;
using UnityEngine;

public abstract class AdventureTraitEffectBase : IAdventureTraitEffect
{
    public virtual void ApplyTo(Grade grade) { }

    public virtual void OnCombatCalculated(Grade grade) { }
}
