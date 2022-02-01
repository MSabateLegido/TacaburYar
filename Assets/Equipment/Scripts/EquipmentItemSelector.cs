using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItemSelector : MonoBehaviour
{

    [SerializeField] private EquipmentItemType equipmentType;
    [SerializeField] private EquipmentItem[] itemsAvailable;
    [SerializeField] private EquipmentItem defaultItem;

    [SerializeField] private EquipmentItemSlot equipmentSlot;

    private EquipmentItem currentItem;

    private void Awake()
    {
        SetCurrentItem();        
    }

    private void SetCurrentItem()
    {
        currentItem = defaultItem;
        equipmentSlot.SetSlotToDefault();
    }

    public void ChangeCurrentItem(EquipmentItem newItem)
    {
        currentItem?.gameObject.SetActive(false);
        currentItem = itemsAvailable[newItem.GetItemIndex()];
        currentItem.gameObject.SetActive(true);
        equipmentSlot.ChangeEquipmentImage(newItem.GetSprite());
        Player.Instance().Stats().UpdatePlayerStats();
    }

    public void UnequipItem()
    {
        if (currentItem != defaultItem)
        {
            currentItem.gameObject.SetActive(false);
            defaultItem.gameObject.SetActive(true);

            EquipmentItem auxItem = currentItem;
            currentItem = defaultItem;
            equipmentSlot.SetSlotToDefault();
            Player.Instance().UnequipItem(auxItem);
        }
    }

    public bool IsEquiped()
    {
        return currentItem != defaultItem;
    }

    public EquipmentItem GetCurrentEquipmentItem()
    {
        EquipmentItem auxItem = currentItem == defaultItem ? null : currentItem;
        return auxItem;
    }


    public Stats GetCurrentEquipmentStats()
    {
        return currentItem?.GetStats();
    }

    
}
