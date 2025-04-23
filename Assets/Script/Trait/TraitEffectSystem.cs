using System.Collections.Generic;
using UnityEngine;

public static class TraitEffectSystem
{
    private static readonly Dictionary<string, ITraitEffect> TraitDic;

    static TraitEffectSystem()
    {
        TraitDic = new Dictionary<string, ITraitEffect>();
    }

    public static void Register<T>(string traitId) where T : ITraitEffect, new()
    {
        TraitDic.TryAdd(traitId, new T());
    }

    public static ITraitEffect GetEffect(string id)
    {
        return TraitDic.GetValueOrDefault(id);
    }
}
