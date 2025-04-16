using System.Collections.Generic;
using UnityEngine;

public static class AdventureTraitEffectSystem
{
    private static readonly Dictionary<string, IAdventureTraitEffect> TraitDic;

    static AdventureTraitEffectSystem()
    {
        TraitDic = new Dictionary<string, IAdventureTraitEffect>();
    }

    public static void Register<T>(string traitId) where T : IAdventureTraitEffect, new()
    {
        TraitDic.TryAdd(traitId, new T());
    }

    public static IAdventureTraitEffect GetEffect(string traitId)
    {
        return TraitDic.GetValueOrDefault(traitId);
    }
}
