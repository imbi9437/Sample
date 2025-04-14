using System;
using Script.Data.Enemy;
using UnityEngine;

namespace Script.Enemy
{
    public enum TraitGrade //todo : 추후 Grade라는 열거형으로 통합 (던전특성, 몬스터 특성, 몬스터 등급, ETC)
    {
        F,
        E,
        D,
        C,
        B,
        A,
        S,
        SS,
        SSS,
        EX
    }
    
    [Serializable]
    public class MonsterTrait
    {
        public MonsterTraitData traitData;
        public TraitGrade grade;
    }
}