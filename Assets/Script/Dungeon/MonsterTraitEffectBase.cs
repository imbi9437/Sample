using Script.Data.General;
using Script.Enemy;
using UnityEngine;

public abstract class MonsterTraitEffectBase : IMonsterTraitEffect
{
    public virtual void ApplyTo(Monster monster, Grade grade) { }
    public virtual void OnPlacingDungeon(Grade grade) { }

    public virtual void OnDungeonCleared(Grade grade) { }

    public virtual void OnRewardCalculated(Grade grade) { }

    public virtual void OnCombat(Grade grade) { }
}
