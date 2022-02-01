using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField] private int experienceToNextLevel;
    [SerializeField] private Stats statsUpgrade;

    public int GetExperienceToNextLevel()
    {
        return experienceToNextLevel;
    }

    public Stats GetStatsUpgrade()
    {
        return statsUpgrade;
    }

    public void SetLevelData(LevelData newData)
    {
        experienceToNextLevel = newData.GetExperienceToNextLevel();
        statsUpgrade = newData.GetStatsUpgrade();
    }
}
