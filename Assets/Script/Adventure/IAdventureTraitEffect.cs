using Script.Data.General;
using UnityEngine;

public interface IAdventureTraitEffect : ITraitEffect
{
    public void OnCombatCalculated(Grade grade);
}
