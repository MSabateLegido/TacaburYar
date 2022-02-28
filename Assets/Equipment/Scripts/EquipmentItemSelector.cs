using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentItemSelector : MonoBehaviour
{
    public UnityEvent onEquipmentChange;

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
        onEquipmentChange.Invoke();
    }

    public void UnequipItem()
    {
        if (currentItem != defaultItem)
        {
            currentItem.gameObject.SetActive(false);
            defaultItem.gameObject.SetActive(true);
            Player.Instance().UnequipItem(currentItem);
            currentItem = defaultItem;
            equipmentSlot.SetSlotToDefault();
            onEquipmentChange.Invoke();
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
