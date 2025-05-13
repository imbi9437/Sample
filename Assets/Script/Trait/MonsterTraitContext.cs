using Script.Data;
using Script.Data.General;
using Script.Trait;
using UnityEngine;

public class MonsterTraitContext : TraitContext
{
    public Grade grade;
    public Race race;
    
    public override TraitCondition GetCondition()
    {
        TraitCondition tempCondition = new TraitCondition();
        tempCondition.Grade = grade;
        tempCondition.Race = race;

        return tempCondition;
    }
}
