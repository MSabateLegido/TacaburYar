using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoolEvent : UnityEvent<bool> { }
public class EquipmentEvent : UnityEvent<EquipmentItem> { }
public class PlayerEquipmentSet : MonoBehaviour
{
    [HideInInspector] public BoolEvent onSwordEquipedChange;
    [HideInInspector] public EquipmentEvent onEquipmentUnequiped;

    //Shield, Sword, Helmet, Shoulders, Armor, Belt, Gloves, Boots
    [SerializeField] private EquipmentItemSelector[] equipmentItems;

    [SerializeField] private EquipmentSetUI equipementUI;

    private void Awake()
    {
        onEquipmentUnequiped = new EquipmentEvent();
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


    public void ChangeEquipmentItem(EquipmentItem itemToEquip)
    {
        EquipmentItem itemToStore = EquipNewItemAndReturnCurrent(itemToEquip);
        if (itemToStore != null)
        {
            UnequipItem(itemToStore);
        }
    }

    public void UnequipItem(EquipmentItem unequipedItem)
    {
        onEquipmentUnequiped.Invoke(unequipedItem);
        Player.Instance().Stats().UpdatePlayerStats();
    }


    public EquipmentItem EquipNewItemAndReturnCurrent(EquipmentItem itemToEquip)
    {
        int equipmentTypeIndex = (int)itemToEquip.GetEquipmentType();

        EquipmentItem currentEquipedItem = equipmentItems[equipmentTypeIndex].GetCurrentEquipmentItem();
        equipmentItems[equipmentTypeIndex].ChangeCurrentItem(itemToEquip);
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
