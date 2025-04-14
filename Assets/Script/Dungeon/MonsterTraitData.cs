using UnityEngine;

namespace Script.Data.Enemy
{
    [CreateAssetMenu(fileName = "MonsterTraitData", menuName = "Scriptable Objects/MonsterTraitData")]
    public class MonsterTraitData : ScriptableObject
    {
        public string id;
        public string traitName;
        
        [TextArea]
        public string traitDescription;
    }
}