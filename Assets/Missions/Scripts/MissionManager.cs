using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionManager : MonoBehaviour
{
    public MissionEvent onStartMission;
    private Mission[] missions;
    private int currentMission;
    private MissionsUI missionsUI;

    private void Awake()
    {
        missions = GetComponentsInChildren<Mission>(true);
        missionsUI = GetComponentInChildren<MissionsUI>();
        Mission.onEndMission = new UnityEvent();
        Mission.onStartNewAction = new MissionActionEvent();
        onStartMission = new MissionEvent();
    }

    private void Start()
    {
        Mission.onEndMission.AddListener(EndCurrentMission);
        StartNextMission();
    }

    private void StartNextMission()
    {
        if (MissionExist())
        {
            missions[currentMission].gameObject.SetActive(true);
            onStartMission.Invoke(missions[currentMission]);
        }
        else
        {
            Debug.Log("No more missions");
        }
    }

    private void EndCurrentMission()
    {
        missions[currentMission].gameObject.SetActive(false);
        currentMission++;
        StartNextMission();
    }

    private bool MissionExist()
    {
        return currentMission < missions.Length;
    }
}
