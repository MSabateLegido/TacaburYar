using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField] int maxHP;
    [SerializeField] int defense;
    [SerializeField] private int attack;
    [SerializeField] float speed;
    //[0]: HP, [1]: Defense, [2]: Attack, [3]: Movement 
    public Stats()
    {
        maxHP = 0;
        defense = 0;
        attack = 0;
        speed = 0;
    }
    public Stats(Stats defaultStats)
    {
        maxHP = defaultStats.GetHP();
        defense = defaultStats.GetDefense();
        attack = defaultStats.GetAttack();
        speed = defaultStats.GetSpeed();
    }

    public int GetHP()
    {
        return maxHP;
    }

    public void MinusHP(int quantity)
    {
        maxHP -= quantity;
    }

    public int GetDefense()
    {
        return defense;
    }

    public int GetAttack()
    {
        return attack;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetStats(Stats newStats)
    {
        maxHP = newStats.GetHP();
        defense = newStats.GetDefense();
        attack = newStats.GetAttack();
        speed = newStats.GetSpeed();
    }

    public void AddStats(Stats statsAdded)
    {
        maxHP += statsAdded.GetHP();
        defense += statsAdded.GetDefense();
        attack += statsAdded.GetAttack();
        speed += statsAdded.GetSpeed();
    }


}
