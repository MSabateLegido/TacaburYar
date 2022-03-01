using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    //Actions poden ser:
    //Explorar zones, buscar items, matar enemics, parlar amb algu, anar a, recollir recursos, etc.

    private MissionAction[] actionsToCompleteMission;
    private int currentAction;

    private Mission nextMission;

    //private Recompense recompenseToCompleteMission;

    private void OnEnable()
    {
        InitializeMission();
    }

    public void InitializeMission()
    {
        actionsToCompleteMission = GetComponentsInChildren<MissionAction>();
        Debug.Log("Mission initialize");
        currentAction = 0;
    }

    public void EndAction()
    {
        currentAction++;
        StartNextAction();
    }

    private void StartNextAction()
    {
        if (actionsToCompleteMission[currentAction] != null)
        {
            actionsToCompleteMission[currentAction].gameObject.SetActive(true);
        } 
        else
        {
            CompleteMission();
        }
    }

    private void CompleteMission()
    {
        //recompenseToCompleteMission.Reward();
        nextMission.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

}
