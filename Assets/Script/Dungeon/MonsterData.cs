using System;
using System.Collections.Generic;
using Script.Data.General;
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
    
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/MonsterData")]
    public class MonsterData : ScriptableObject
    {
        [Header("Data")]
        public string id;
        public string monsterName;  //몬스터 이름
        public Sprite icon;

        public MonsterType type;
        public Race race;
        public Element element;
        public Grade grade;
        public List<MonsterTrait> baseTraits;   //기본 특성
        
        [Space(10), Header("Stat")] 
        public CombatData baseCombatData;   // 기본 스탯
    }
}