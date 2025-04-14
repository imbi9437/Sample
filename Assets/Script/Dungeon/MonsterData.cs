using System;
using System.Collections.Generic;
using Script.Enemy;
using UnityEngine;

namespace Script.Data.Enemy
{
    public enum MonsterType
    {
        Normal,
        Named,
        Unique,
        Boss
    }

    public enum MonsterRace //todo : 추후 몬스터의 대단위 분류로 변경해야 할 듯 EX) 언데드, 아인종, 악마, 수인 , ETC
    {
        Human,
        Undead,
        Orc,
        Goblin,
        Demon,
    }

    public enum MonsterElement
    {
        None,
        Fire,
        Water,
        Earth,
        Wind,
        Grass,
        Ice,
        Light,
        Dark
    }

    public enum MonsterGrade
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
    
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/MonsterData")]
    public class MonsterData : ScriptableObject
    {
        [Header("Data")]
        public string id;
        public string monsterName;  //몬스터 이름
        public Sprite icon;

        public MonsterType type;
        public MonsterRace race;
        public MonsterElement element;
        public MonsterGrade grade;
        public List<MonsterTrait> baseTraits;   //기본 특성
        
        [Space(10), Header("Stat")] 
        public CombatData baseCombatData;   // 기본 스탯
    }
}