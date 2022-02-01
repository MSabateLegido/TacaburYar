using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{

    [SerializeField] Stats defaultEnemyStats;
    [SerializeField] GameObject[] itemsToDrop;
    [SerializeField] float[] dropProbabilities;
    [SerializeField] int minXPGiven;
    [SerializeField] int maxXPGiven;

    public Stats GetEnemyStats()
    {
        return defaultEnemyStats;
    }

    public float[] GetDropProbabilities()
    {
        return dropProbabilities;
    }

    public GameObject GetItemDropped(int item)
    {
        return itemsToDrop[item];
    }

    public int GetXPGiven()
    {
        return Random.Range(minXPGiven, maxXPGiven);
    }

    public int ItemsToDropCount()
    {
        return itemsToDrop.Length;
    }
}
