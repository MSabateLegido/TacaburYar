using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAction_TalkToGhost : MissionAction
{
    [SerializeField] private GameObject ghostInstance;

    public override void CompleteAction()
    {
        ghostInstance.SetActive(false);
        base.CompleteAction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CompleteAction();
        }
    }



}
