using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stats", order = 1)]
public class Stats : ScriptableObject
{
    [SerializeField] int maxHP;
    [SerializeField] int defense;
    [SerializeField] int attack;
    [SerializeField] float speed;
    //[0]: HP, [1]: Defense, [2]: Attack, [3]: Movement 

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
