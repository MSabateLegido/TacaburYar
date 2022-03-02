using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class Mission : MonoBehaviour
{
    public static UnityEvent OnEndMission;
    //Actions poden ser:
    //Explorar zones, buscar items, matar enemics, parlar amb algu, anar a, recollir recursos, etc.
    private MissionAction[] actionsToCompleteMission;
    private int currentAction;

    //private Recompense recompenseToCompleteMission;

    private void OnEnable()
    {
        InitializeMission();
    }

    public void InitializeMission()
    {
        actionsToCompleteMission = GetComponentsInChildren<MissionAction>();
        currentAction = 0;
    }

    public void CompleteAction()
    {
        currentAction++;
        StartNextAction();
    }

    private void StartNextAction()
    {
        if (ActionExists())
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
        OnEndMission.Invoke();
    }
    
    private bool ActionExists()
    {
        return currentAction < actionsToCompleteMission.Length;
    }
}
