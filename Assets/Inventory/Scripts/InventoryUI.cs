using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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




















    public bool OldStoreItem(Item itemToStore)
    {
        Debug.Log(itemToStore.GetItemType());
        bool stored = false;
        if (itemToStore.GetItemType() != ItemType.EquipmentItem)
        {
            stored = StoreItemIfAlreadyInInventory(itemToStore);
        }

        if (!stored)
        {
            stored = StoreItemInAnEmptySlot(itemToStore);
        }
        return stored;
    }

    private bool StoreItemIfAlreadyInInventory(Item itemToStore)
    {
        bool alreadyStored = false;
        int i = 0;
        ItemSlot slot;
        do
        {
            slot = itemSlots[i];
            if (AlreadyStored(itemToStore, slot) && !slot.SlotFull())
            {
                slot.AddItemToFilledSlot(1);
                alreadyStored = true;
            }
            i++;
        } while (!alreadyStored && i < itemSlots.Length);
        return alreadyStored;
    }

    private bool StoreItemInAnEmptySlot(Item itemToStore)
    {
        ItemSlot slot;
        bool stored = false;
        int i = 0;
        do
        {
            slot = itemSlots[i];
            if (slot.IsEmpty())
            {
                slot.FillEmptySlot(itemToStore, 1);
                stored = true;
            }
            i++;
        } while (!stored && i < itemSlots.Length);
        return stored;
    }

    private bool AlreadyStored(Item itemToStore, ItemSlot slot)
    {
        return !slot.IsEmpty() && itemToStore.GetItemType() == slot.GetStoredItemType();
    }

    public void OpenInventoryUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void CloseInventoryUI()
    {
        gameObject.SetActive(false);
    }
}
