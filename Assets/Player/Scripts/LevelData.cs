using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField] private int experienceToLevelUp;
    [SerializeField] private StatsScriptableObject statsUpgrade;

    public int GetExperienceToNextLevel()
    {
        return experienceToLevelUp;
    }

    public Stats GetLevelStats()
    {
        return statsUpgrade.GetStats();
    }

    public void SetLevelData(LevelData newData)
    {
        experienceToLevelUp = newData.GetExperienceToNextLevel();
        //statsUpgrade = newData.GetStatsUpgrade();
    }
}
