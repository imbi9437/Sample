using System.Collections.Generic;
using System.Linq;
using Script.Data;
using Script.Data.General;
using Script.Generic.Manager;
using Script.Trait;
using UnityEngine;

public class TraitManager : MonoSingleton<TraitManager>
{
    public List<TraitInstance> CalculateRaceTrait(TraitContext context)
    {
        List<TraitInstance> tempList = new List<TraitInstance>();
        TraitCondition condition = context.GetCondition();

        RaceData raceData = DataManager.GetRaceData(condition.Race);
        
        foreach (var traitId in raceData.traitIds)
        {
            TraitData data = DataManager.GetTraitData(traitId);
            DynamicTraitRuleData ruleData = DataManager.GetRuleData(traitId);
            TraitInstance instance = CalculateTraitInstance(condition, data, ruleData);
            
            if (instance == null) continue;
            if (tempList.Contains(instance)) continue;
            
            tempList.Add(instance);
        }

        return tempList;
    }
    
    /// <summary>
    /// 특성 부여 여부 계산
    /// </summary>
    public bool CalculateTraitGrant(TraitCondition condition, DynamicTraitRuleData ruleData)
    {
        var randomValue = Random.Range(0, 101);
        if (ruleData.GradeWeight[condition.Grade] > randomValue) return true;
        return false;
    }
    
    /// <summary>
    /// 특성 부여 확정 시 해당 특성 등급 계산
    /// </summary>
    public TraitInstance CalculateTraitInstance(TraitCondition condition ,TraitData trait ,DynamicTraitRuleData ruleData)
    {
        var weightMap = ruleData.ApplyTraitGradeWeight[condition.Grade];
        int totalWeight = weightMap.Values.Sum();
        int randomValue = Random.Range(0, totalWeight);
        int cumulative = 0;

        foreach (var kvp in weightMap.OrderBy(kv => kv.Key))
        {
            cumulative += kvp.Value;

            if (randomValue >= cumulative) continue;
            TraitInstance instance = new TraitInstance();
            instance.traitData = trait;
            instance.grade = kvp.Key;
            return instance;
        }
        
        return null;
    }
}
