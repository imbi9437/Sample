using System;
using System.Collections.Generic;
using Script.Enemy;
using Script.Enum;
using Script.Generic.Scheduler;
using Script.Trait;
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
        //CreateEventGuid = Scheduler.Instance.Schedule(CreateDungeon, Interval, true);
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
    
    private void CreateDungeon()
    {
        // todo : Dungeon Factory static 클래스 생성 및 인스턴스화 위임 & 특성 효과 발현 인터페이스 실행
        
        Dungeon dungeon = new Dungeon();

        dungeon.id = Guid.NewGuid().ToString();
        dungeon.pos = CalculateDungeonPos();
        dungeon.environment = CalculateEnvironment();
        dungeon.difficulty = CalculateDifficulty();
        dungeon.size = CalculateSize();
        dungeon.monsters = SelectMonsters();
        dungeon.traps = SelectTraps();
        dungeon.traits = SelectTraits();

        foreach (var trait in dungeon.traits)
        {
            var effect = TraitEffectSystem.GetEffect(trait.traitData.traitId);
            var context = new DungeonTraitContext();
            
            effect.ApplyTo(context);
        }

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

    private List<Monster> SelectMonsters()
    {
        return new List<Monster>();
    }

    private List<TrapData> SelectTraps()
    {
        return null;
    }

    private List<TraitInstance> SelectTraits()
    {
        return new List<TraitInstance>();
    }

    private List<ItemData> SelectRewards()
    {
        return null;
    }

    #endregion
}
