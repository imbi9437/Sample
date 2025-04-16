using UnityEngine;

namespace Script.Data.Order
{
    [CreateAssetMenu(fileName = "AdventureTraitData", menuName = "Scriptable Objects/AdventureTraitData")]
    public class AdventureTraitData : ScriptableObject
    {
        public string id;
        public string traitName;

        [TextArea] 
        public string description;
    }
}