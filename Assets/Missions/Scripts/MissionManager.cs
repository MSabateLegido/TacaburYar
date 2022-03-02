using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionManager : MonoBehaviour
{
    private Mission[] missions;
    private int currentMission;

    private void Awake()
    {
        missions = GetComponentsInChildren<Mission>(true);
        Mission.OnEndMission = new UnityEvent();
        Mission.OnEndMission.AddListener(EndCurrentMission);
        Debug.Log(missions.Length);
        StartNextMission();
    }

    private void EndCurrentMission()
    {
        missions[currentMission].gameObject.SetActive(false);
        currentMission++;
        StartNextMission();
    }

    private void StartNextMission()
    {
        if (MissionExist())
        {
            missions[currentMission].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("No more missions");
        }
    }

    private bool MissionExist()
    {
        return currentMission < missions.Length;
    }
}
