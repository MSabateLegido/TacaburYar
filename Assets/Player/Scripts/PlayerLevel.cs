using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int playerLevel;
    private int currentExperience;
    private int experienceToNextLevel;

    [SerializeField] LevelData[] levelsData;
    private LevelData currentLevelData;

    private void Awake()
    {
        currentLevelData = ScriptableObject.CreateInstance<LevelData>();
        currentLevelData.SetLevelData(levelsData[0]);
        playerLevel = 1;
        experienceToNextLevel = currentLevelData.GetExperienceToNextLevel();
    }

    private void Start()
    {
        Player.Instance().Stats().UpdatePlayerStats();
    }

    public void GainExperience(int experience)
    {
        currentExperience += experience;
        CheckNewLevel();
    }

    private void CheckNewLevel()
    {
        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevelData.SetLevelData(levelsData[playerLevel]);
        playerLevel++;
        experienceToNextLevel += currentLevelData.GetExperienceToNextLevel();
        Player.Instance().Stats().UpdatePlayerStats();
    }

    public int GetLevel()
    {
        return playerLevel;
    }

    public Stats GetLevelStats()
    {
        return currentLevelData.GetStatsUpgrade();
    }
}
