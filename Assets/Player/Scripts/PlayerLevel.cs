using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    [HideInInspector] public UnityEvent onLevelUp;

    private int playerLevel;
    private int currentExperience;
    private int experienceToNextLevel;

    [SerializeField] LevelData[] levelsData;

    private void Awake()
    {
        experienceToNextLevel = GetCurrentLevelData().GetExperienceToNextLevel();
    }

    private void Start()
    {
        //Player.Instance().Stats().UpdatePlayerStats();
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
        playerLevel++;
        experienceToNextLevel += levelsData[playerLevel-1].GetExperienceToNextLevel();
        onLevelUp.Invoke();
    }

    public int GetLevel()
    {
        return playerLevel;
    }

    public Stats GetLevelStats()
    {
        return GetCurrentLevelData().GetLevelStats();
    }

    private LevelData GetCurrentLevelData()
    {
        return levelsData[playerLevel];
    }
}
