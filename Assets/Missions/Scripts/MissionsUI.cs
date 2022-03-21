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
    [SerializeField] private GameObject notificationIcon;

    private void Start()
    {
        GetComponent<MissionManager>().onStartMission.AddListener(SetNewMission);
        Mission.onStartNewAction.AddListener(AddNewObjective);
        //Mission.onEndMission.AddListener(ResetMissionPanel);
    }

    public void SetNewMission(Mission newMission)
    {
        Debug.Log("Set new mission " + Time.time);
        SetMissionTitle(newMission.GetMissionName());
        ResetMissionPanel();
        if (!missionsPanel.activeSelf)
        {
            notificationIcon.SetActive(true);
        }
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
        if (!missionsPanel.activeSelf)
        {
            notificationIcon.SetActive(true);
        }
    }

    public void OpenCloseMissionsPanel()
    {
        missionsPanel.SetActive(!missionsPanel.activeSelf);
        if (notificationIcon.activeSelf)
        {
            notificationIcon.SetActive(false);
        }
    }

}
