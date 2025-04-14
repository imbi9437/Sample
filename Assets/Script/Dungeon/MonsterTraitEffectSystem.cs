using System.Collections.Generic;
using Script.Enemy;
using UnityEngine;

public static class MonsterTraitEffectSystem
{
    private static readonly Dictionary<string, IMonsterTraitEffect> TraitDic;

    static MonsterTraitEffectSystem()
    {
        TraitDic = new Dictionary<string, IMonsterTraitEffect>();
    }

    public static void Register<T>(string traitId) where T : IMonsterTraitEffect, new()
    {
        TraitDic.TryAdd(traitId, new T());
    }

    public static IMonsterTraitEffect GetEffect(string traitId)
    {
        return TraitDic.GetValueOrDefault(traitId);
    }
}
