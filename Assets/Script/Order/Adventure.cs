using System;
using System.Collections.Generic;
using Script.Data.General;
using Script.Order.Data;
using UnityEngine;

namespace Script.Order
{
    [Serializable]
    public class Adventure
    {
        public string name;

        public Race race;
        public Element element;
        
        public CombatData stat;
        public Job job;
        public List<AdventureTrait> traits;
    }
}