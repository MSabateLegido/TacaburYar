using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    [SerializeField] private MissionAction actionToComplete;

    private void OnTriggerEnter(Collider other)
    {
        actionToComplete.CompleteAction();
    }
}
