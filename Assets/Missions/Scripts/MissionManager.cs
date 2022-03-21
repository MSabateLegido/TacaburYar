using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(MissionsUI))]
public class MissionManager : MonoBehaviour
{
    public MissionEvent onStartMission;
    private Mission[] missions;
    private int currentMission;

    private void Awake()
    {
        missions = GetComponentsInChildren<Mission>(true);
        Mission.onEndMission = new UnityEvent();
        Mission.onStartNewAction = new MissionActionEvent();
        onStartMission = new MissionEvent();
        
    }

    private void Start()
    {
        Mission.onEndMission.AddListener(EndCurrentMission);
        Invoke(nameof(StartNextMission), 1f);
    }

    private void StartNextMission()
    {
        if (MissionExist())
        {
            Debug.Log("Start next missions " + Time.time);
            onStartMission.Invoke(missions[currentMission]);
            missions[currentMission].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("No more missions");
        }
    }

    private void EndCurrentMission()
    {
        Debug.Log("endCurrentMission " + Time.time);
        missions[currentMission].gameObject.SetActive(false);
        currentMission++;
        StartNextMission();
    }

    private bool MissionExist()
    {
        return currentMission < missions.Length;
    }

    public void SkipCurrentAction()
    {
        missions[currentMission].CompleteAction();
    }
}
