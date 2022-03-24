using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionsUI : MonoBehaviour
{

    [SerializeField] private GameObject missionsPanel;

    [SerializeField] private TextMeshProUGUI missionTitle;
    [SerializeField] private GameObject missionObjectives;
    private TextMeshProUGUI currentActionText;
    private int objectivesNumber = 0;

    [SerializeField] private TextMeshProUGUI objectiveTextPrefab;

    private void Awake()
    {
        MissionManager.onStartMission.AddListener(SetNewMission);
        Mission.onStartNewAction.AddListener(AddNewObjective);
    }
    private void Start()
    {
       
    }

    public void SetNewMission(Mission newMission)
    {
        Debug.Log("Set new mission " + Time.time);
        SetMissionTitle(newMission.GetMissionName());
        ResetMissionPanel();
    }

    private void ResetMissionPanel()
    {
        Debug.Log("resetMissionPanel " + Time.time);
        foreach (TextMeshProUGUI objective in missionObjectives.GetComponentsInChildren<TextMeshProUGUI>())
        {
            Debug.Log(objective.name);
            Destroy(objective.gameObject);
        }
        objectivesNumber = 0;
        currentActionText = null;
    }

    public void SetMissionTitle(string newTitle)
    {
        missionTitle.text = newTitle;
    }

    
    public void AddNewObjective(MissionAction action)
    {
        Debug.Log("addnewObjective " + Time.time);
        if (currentActionText != null) { currentActionText.fontStyle = FontStyles.Strikethrough; }
        currentActionText = Instantiate(objectiveTextPrefab, missionObjectives.transform);
        currentActionText.text = "- " + action.GetObjective();
        currentActionText.GetComponent<RectTransform>().offsetMax = new Vector2(0,-objectivesNumber*100);
        objectivesNumber++;

    }

    public void OpenCloseMissionsPanel()
    {
        missionsPanel.SetActive(!missionsPanel.activeSelf);
    }

}
