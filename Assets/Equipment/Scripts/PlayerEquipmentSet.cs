using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentSet : MonoBehaviour
{

    //Helmet, Shoulders, Armor, Sword, Shield, Belt, Gloves, Boots
    [SerializeField] private EquipmentItemSelector[] equipmentItems;

    [SerializeField] private EquipmentSetUI equipementUI;

    private void Awake()
    {
        equipmentItems = GetComponentsInChildren<EquipmentItemSelector>();
    }
    public EquipmentItem EquipNewItemAndReturnCurrent(EquipmentItem newEquipment)
    {
        int equipmentTypeIndex = (int)newEquipment.GetEquipmentType();

        EquipmentItem currentEquipedItem = equipmentItems[equipmentTypeIndex].GetCurrentEquipmentItem();
        equipmentItems[equipmentTypeIndex].ChangeCurrentItem(newEquipment);
        return currentEquipedItem;
    }

    public Stats GetEquipmentStats()
    {
        Stats auxStats = new Stats();
        foreach (EquipmentItemSelector item in equipmentItems)
        { 
            auxStats.AddStats(item.GetCurrentEquipmentStats());  
        }
        return auxStats;
    }

    public void OpenOrCloseEquipmentUI(bool open)
    {
        if (open)
        {
            equipementUI.OpenEquipmentUI();
        } 
        else
        {
            equipementUI.CloseEquipmentUI();
        }
        
    }

    public EquipmentItemSelector[] GetEquipmentSelectors()
    {
        return equipmentItems;
    }
}
