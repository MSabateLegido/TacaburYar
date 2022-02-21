using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stats", order = 1)]
public class StatsScriptableObject : ScriptableObject
{
    [SerializeField] Stats stats;
    public Stats GetStats()
    {
        return stats;
    }
}
