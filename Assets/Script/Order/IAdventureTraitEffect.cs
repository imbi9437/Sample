using Script.Data.General;
using UnityEngine;

public interface IAdventureTraitEffect
{
    public void ApplyTo(Grade grade);

    public void OnCombatCalculated(Grade grade);
}
