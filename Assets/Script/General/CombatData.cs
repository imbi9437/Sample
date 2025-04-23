using System;
using UnityEngine;

[Serializable]
public class CombatData
{
    public int hp;
    public int attack;
    public int defence;

    public CombatData CopyTo()
    {
        CombatData copy = new CombatData
        {
            hp = hp,
            attack = attack,
            defence = defence
        };

        return copy;
    }

    public static CombatData operator *(CombatData combat, float multiplier)
    {
        var temp = combat.CopyTo();
        temp.hp = Mathf.RoundToInt(combat.hp * multiplier);
        temp.attack = Mathf.RoundToInt(combat.attack * multiplier);
        temp.defence = Mathf.RoundToInt(combat.defence * multiplier);

        return temp;
    }
}
