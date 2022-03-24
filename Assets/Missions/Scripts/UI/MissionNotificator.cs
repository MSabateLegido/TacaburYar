using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionNotificator : MonoBehaviour
{

    [SerializeField] private GameObject notificationIcon;

    void Start()
    {
        MissionManager.onStartMission.AddListener(NotifyMissionsUpdate);
        Mission.onStartNewAction.AddListener(NotifyActionUpdate);
    }

    private void NotifyMissionsUpdate(Mission mission)
    {
        notificationIcon.SetActive(true);
    }

    private void NotifyActionUpdate(MissionAction action)
    {
        notificationIcon.SetActive(true);
    }

    public void CloseNotification()
    {
        notificationIcon.SetActive(false);
    }
}
