using System;
using Script.Data.Enemy;
using Script.Data.General;
using UnityEngine;

namespace Script.Enemy
{
    [Serializable]
    public class MonsterTrait
    {
        public MonsterTraitData traitData;
        public Grade grade;
    }
}