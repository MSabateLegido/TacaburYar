using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class MissionEvent : UnityEvent<Mission> { }
public class MissionActionEvent : UnityEvent<MissionAction> { }
public class Mission : MonoBehaviour
{
    public static UnityEvent onEndMission = new UnityEvent();
    public static MissionActionEvent onStartNewAction = new MissionActionEvent();
    [SerializeField] private string missionName;
    private MissionAction[] actionsToCompleteMission;
    private int currentAction;
    

    //private Recompense recompenseToCompleteMission;

    private void OnEnable()
    {
        InitializeMission();
    }

    public void InitializeMission()
    {
        actionsToCompleteMission = GetComponentsInChildren<MissionAction>(true);
        currentAction = 0;
        StartNextAction();
    }

    private void StartNextAction()
    {
        if (ActionExists())
        {
            actionsToCompleteMission[currentAction].gameObject.SetActive(true);
            onStartNewAction.Invoke(actionsToCompleteMission[currentAction]);
        } 
        else
        {
            CompleteMission();
        }
    }
    public void CompleteAction()
    {
        actionsToCompleteMission[currentAction].gameObject.SetActive(false);
        currentAction++;
        StartNextAction();
    }

    private void CompleteMission()
    {
        onEndMission.Invoke();
    }

    private bool ActionExists()
    {
        return currentAction < actionsToCompleteMission.Length;
    }

    public MissionAction GetCurrentAction()
    {
        return actionsToCompleteMission[currentAction];
    }
    
    public string GetMissionName()
    {
        return missionName;
    }

    
}
