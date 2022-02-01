using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryEditor : MonoBehaviour
{
    [MenuItem("Tacabur Yar/Inventory/Active Inventory")]
    static void ActiveInventory()
    {
        //Inventory
        //EquimentSet
        GameObject parentGO = GameObject.Find("UserInterface");
        RectTransform[] children = parentGO.GetComponentsInChildren<RectTransform>(true);
        foreach (RectTransform child in children)
        {
            if (child.name.Equals("Inventory") || child.name.Equals("EquipmentPanel"))
            {
                child.gameObject.SetActive(true);
            }
        }

        //PlayerCamera
        GameObject.Find("PlayerTest").GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
        
    }

    [MenuItem("Tacabur Yar/Inventory/Desactive Inventory")]
    static void DesactiveInventory()
    {
        //Inventory
        //EquimentSet
        GameObject parentGO = GameObject.Find("UserInterface");
        RectTransform[] children = parentGO.GetComponentsInChildren<RectTransform>(true);
        foreach (RectTransform child in children)
        {
            if (child.name.Equals("Inventory") || child.name.Equals("EquipmentPanel"))
            {
                child.gameObject.SetActive(false);
            }
        }

        //PlayerCamera
        GameObject.Find("PlayerTest").GetComponentInChildren<Camera>(true).gameObject.SetActive(false);
    }
}
