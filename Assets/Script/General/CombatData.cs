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
}
