using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithUI : MonoBehaviour
{
    [SerializeField] GameObject playerInventory;
    [SerializeField] GameObject blacksmithCamera;

    [SerializeField] GameObject equipmentTypeSelectorPanel;
    [SerializeField] GameObject[] itemsAvailableSelectorPanels;
    [SerializeField] GameObject craftingPanel;


    public void OpenBlacksmithUI()
    {
        gameObject.SetActive(true);
        playerInventory.SetActive(true);
        blacksmithCamera.SetActive(true);
    }

    public void CloseBlacksmithUI()
    {
        equipmentTypeSelectorPanel.SetActive(true);
        foreach (GameObject panel in itemsAvailableSelectorPanels)
        {
            panel.SetActive(false);
        }
        craftingPanel.SetActive(false);
        gameObject.SetActive(false);
        playerInventory.SetActive(false);
        blacksmithCamera.SetActive(false);
    }

    public void ResetBlacksmithUI()
    {
        equipmentTypeSelectorPanel.SetActive(true);
        foreach (GameObject panel in itemsAvailableSelectorPanels)
        {
            panel.SetActive(false);
        }
        craftingPanel.SetActive(false);
    }
}
