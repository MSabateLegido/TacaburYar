using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSetUI : MonoBehaviour
{
    [SerializeField] GameObject playerCamera;
    public void OpenEquipmentUI()
    {
        gameObject.SetActive(true);
        playerCamera.SetActive(true);
    }

    public void CloseEquipmentUI()
    {
        gameObject.SetActive(false);
        playerCamera.SetActive(false);
    }
}
