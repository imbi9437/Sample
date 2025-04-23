using System.Collections.Generic;
using Script.Data;
using UnityEngine;

namespace Script.Generic.Manager
{
    public static partial class DataManager
    {
        //todo : 메인 파샬클래스는 Json Read & Write 기능만 관리하는걸로

        static DataManager()
        {
            _combatTemplateData = new Dictionary<string, CombatTemplateData>();
            _monsterBaseData = new Dictionary<string, MonsterBaseData>();
            _monsterVariantData = new Dictionary<string, MonsterVariantData>();
        }
    }
}