using System.Collections.Generic;
using UnityEngine;

public static class DungeonTraitEffectSystem
{
    private static readonly Dictionary<string, IDungeonTraitEffect> _traitDic;

    static DungeonTraitEffectSystem()
    {
        _traitDic = new Dictionary<string, IDungeonTraitEffect>();
    }

    public static void Register<T>(string traitId) where T : IDungeonTraitEffect, new()
    {
        _traitDic.TryAdd(traitId, new T());
    }

    public static IDungeonTraitEffect GetEffect(string traitId)
    {
        return _traitDic.GetValueOrDefault(traitId);
    }
}
