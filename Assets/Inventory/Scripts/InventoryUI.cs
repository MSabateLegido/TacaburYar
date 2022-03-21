using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{

    private ItemSlot[] itemSlots;


    private void Awake()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
    }
    public void StoreItem(Item item, bool stacked)
    {
        if (stacked)
        {
            int slot = SearchForFilledSlot(item);
            itemSlots[slot].AddItemToFilledSlot(1);
        }
        else
        {
            int slot = SearchForEmptySlot();
            itemSlots[slot].FillSlot(item);
        }
    }

    private int SearchForFilledSlot(Item item)
    {
        bool found = false;
        int i = 0;
        while (!found && i < itemSlots.Length)
        {
            if (itemSlots[i].HasStored(item))
            {
                found = true;

            }
            else
            {
                i++;
            }
        }
        return i;
    }

    private int SearchForEmptySlot()
    {
        bool found = false;
        int i = 0;
        while (!found && i < itemSlots.Length)
        {
            if (itemSlots[i].IsEmpty())
            {
                found = true;
            }
            else
            {
                i++;
            }
        }
        return i;
    }


    public void AddOnEmptySlotListeners(UnityAction action)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            slot.AddOnEmptySlotListener(action);
        }
    }
}
