using UnityEngine;

namespace Script.Data.Enemy
{
    [CreateAssetMenu(fileName = "DungeonTraitData", menuName = "Scriptable Objects/DungeonTraitData")]
    public class DungeonTraitData : ScriptableObject
    {
        public string id;
        public string traitName;

        [TextArea] 
        public string description;
    }
}