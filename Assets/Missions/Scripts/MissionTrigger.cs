using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    public Mission missionToActive;

    private void OnTriggerEnter(Collider other)
    {
        missionToActive.InitializeMission();
    }
}
