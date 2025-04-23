using System;
using System.Collections.Generic;
using Script.Data;
using Script.Data.General;
using Script.Trait;
using UnityEngine;

namespace Script.Order
{
    [Serializable]
    public class Adventure
    {
        public string name;

        public Race race;
        public Element element;
        
        public AdventurerJobData job;
        
        public CombatData stat;
        public List<TraitInstance> traits;
    }
}