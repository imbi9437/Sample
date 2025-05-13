using UnityEngine;

namespace Script.Trait
{
    public abstract class TraitContext : ITraitContextProvider
    {
        public abstract TraitCondition GetCondition();
    }
}