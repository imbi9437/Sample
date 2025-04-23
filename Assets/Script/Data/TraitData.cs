using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Data
{
    /// <summary>특성 데이터</summary>
    [Serializable]
    public class TraitData
    {
        public string traitId;
        public string name;
        public string effectType;
        public string referencedId;
        public List<int> effectValues;  
        public string description;
    }
}