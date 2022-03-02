using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionsUI : MonoBehaviour
{

    [SerializeField] private GameObject missionsPanel;

    [SerializeField] private TextMeshProUGUI missionTitle;
    [SerializeField] private TextMeshProUGUI missionObjectives;

    public void OpenCloseMissionsPanel()
    {
        missionsPanel.SetActive(!missionsPanel.activeSelf);
        missionTitle.fontStyle = FontStyles.Strikethrough;
    }
}
