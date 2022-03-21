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
    private Dictionary<string, EquipmentItemSelector> equipmentSet;

    private void Awake()
    {
        equipmentSet = new Dictionary<string, EquipmentItemSelector>();
        foreach (EquipmentItemSelector selector in equipmentItems)
        {
            equipmentSet.Add(selector.tag, selector);
        }
        onEquipmentUnequiped = new EquipmentEvent();
        onSwordEquipedChange = new BoolEvent();
        
        
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
        EquipmentItem currentEquipedItem = equipmentSet[itemToEquip.GetItemName()].GetCurrentEquipmentItem();
        equipmentSet[itemToEquip.GetItemName()].ChangeCurrentItem(itemToEquip);
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
    

    public EquipmentItemSelector[] GetEquipmentSelectors()
    {
        return equipmentItems;
    }
}
