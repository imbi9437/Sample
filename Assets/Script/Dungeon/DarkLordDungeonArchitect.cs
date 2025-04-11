using System;
using System.Collections.Generic;
using Script.Data.Enemy;
using Script.Enemy;
using Script.Generic.Scheduler;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class DarkLordDungeonArchitect : MonoSingleton<DarkLordDungeonArchitect>
{
    [ShowInInspector]
    public Dictionary<string, Dungeon> DungeonDic;

    [ShowInInspector]
    public Guid CreateEventGuid;
    public float Interval;
    //마왕의 던전 생성 및 관리 시스템
    //기능
    /*
     * 랜덤 던전 생성
     * 던전 생성 카운트
     * 던전 정보 저장 및 로드
     * 
     */

    protected override void Awake()
    {
        base.Awake();

        DungeonDic = new Dictionary<string, Dungeon>();
    }

    private void Start()
    {
        CreateEventGuid = Scheduler.Instance.Schedule(CreateDungeon, Interval, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateDungeon();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            CreateEventGuid = Scheduler.Instance.Schedule(CreateDungeon, Interval, true);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Scheduler.Instance.Cancel(CreateEventGuid);
        }
    }

    #region 던전 생성

    /// <summary>
    /// 추후 DB에서 생성하고 인스턴스하기
    /// 던전 데이터 클래스 생성자로 바꾸기
    /// </summary>
    private void CreateDungeon()
    {
        Dungeon dungeon = new Dungeon();

        dungeon.id = Guid.NewGuid().ToString();
        dungeon.pos = CalculateDungeonPos();
        dungeon.environment = CalculateEnvironment();
        dungeon.difficulty = CalculateDifficulty();
        dungeon.size = CalculateSize();
        dungeon.monsters = SelectMonsters();
        dungeon.traps = SelectTraps();
        dungeon.traits = SelectTraits();

        DungeonDic.TryAdd(dungeon.id, dungeon);
    }

    private Vector2Int CalculateDungeonPos()
    {
        return new Vector2Int(Random.Range(-10, 10), Random.Range(-10, 10));
    }

    private DungeonEnv CalculateEnvironment()
    {
        return EnumUtil<DungeonEnv>.GetRandom();
    }

    private Difficulty CalculateDifficulty()
    {
        return EnumUtil<Difficulty>.GetRandom();
    }

    private Size CalculateSize()
    {
        
        return EnumUtil<Size>.GetRandom();
    }

    private List<MonsterData> SelectMonsters()
    {
        return null;
    }

    private List<TrapData> SelectTraps()
    {
        return null;
    }

    private List<DungeonTraitData> SelectTraits()
    {
        return null;
    }

    private List<ItemData> SelectRewards()
    {
        return null;
    }

    #endregion
}
