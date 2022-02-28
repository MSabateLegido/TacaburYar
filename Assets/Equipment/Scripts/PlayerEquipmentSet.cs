using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoolEvent : UnityEvent<bool> { }
public class PlayerEquipmentSet : MonoBehaviour
{
    [HideInInspector] public BoolEvent onSwordEquipedChange;

    //Shield, Sword, Helmet, Shoulders, Armor, Belt, Gloves, Boots
    [SerializeField] private EquipmentItemSelector[] equipmentItems;

    [SerializeField] private EquipmentSetUI equipementUI;

    private void Awake()
    {
        onSwordEquipedChange = new BoolEvent();
        equipmentItems = GetComponentsInChildren<EquipmentItemSelector>();
        
    }

    private void Start()
    {
        foreach (EquipmentItemSelector selector in equipmentItems)
        {
            selector.onEquipmentChange.AddListener(CheckEquipedSword);
        }
    }
    public EquipmentItem EquipNewItemAndReturnCurrent(EquipmentItem newEquipment)
    {
        int equipmentTypeIndex = (int)newEquipment.GetEquipmentType();

        EquipmentItem currentEquipedItem = equipmentItems[equipmentTypeIndex].GetCurrentEquipmentItem();
        equipmentItems[equipmentTypeIndex].ChangeCurrentItem(newEquipment);
        return currentEquipedItem;
    }

    private void CheckEquipedSword()
    {
        onSwordEquipedChange.Invoke(equipmentItems[(int)EquipmentItemType.Sword].IsEquiped());
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
