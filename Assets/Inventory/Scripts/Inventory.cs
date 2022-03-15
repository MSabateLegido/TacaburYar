using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> inventory;
    private InventoryUI userInterface;

    private ItemSlot[] itemSlots;

    [SerializeField] private EquipmentItem[] test;

    public void Awake()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
        Test();
    }

    private void Test()
    {
        foreach (EquipmentItem item in test)
        {
            StoreItem(item);
        }
    }

    public void UseItemsToCraft(CraftingDataNeeded itemsNeeded)
    {
        for (int i = 0; i < itemsNeeded.GetItemTypes().Length; i++)
        {
            UseItems(itemsNeeded.GetItemTypes()[i], itemsNeeded.GetQuantities()[i]);
        }
    }

    private void UseItems(ItemType type, int quantity)
    {
        int quantityLeft = quantity;
        foreach (ItemSlot slot in itemSlots)
        {
            if (quantityLeft > 0 && !slot.IsEmpty() && slot.GetStoredItemType() == type)
            {
                quantityLeft = slot.MinusItemQuantity(quantityLeft);
            }
        }
    }

    public bool EnoughSpaceInInventory()
    {
        bool emptySpace = false;
        int i = 0;
        do
        {
            if (itemSlots[i].IsEmpty())
            {
                emptySpace = true;
            }
            i++;
        } while (!emptySpace && i < itemSlots.Length);
        return emptySpace;
    }


    public bool EnoughItems(CraftingDataNeeded itemsNeeded)
    {
        int[] itemsQuantityStored = new int[]
        {
            CountItemsOfType(itemsNeeded.GetItemTypes()[0]),
            CountItemsOfType(itemsNeeded.GetItemTypes()[1]),
            CountItemsOfType(itemsNeeded.GetItemTypes()[2])
        };
        return itemsQuantityStored[0] >= itemsNeeded.GetQuantities()[0] &&
            itemsQuantityStored[1] >= itemsNeeded.GetQuantities()[1] &&
            itemsQuantityStored[2] >= itemsNeeded.GetQuantities()[2];
    }

    private int CountItemsOfType(ItemType type)
    {
        int quantity = 0;
        foreach (ItemSlot slot in itemSlots)
        {
            if (!slot.IsEmpty() && slot.GetStoredItemType() == type) 
            {
                quantity += slot.GetQuantity();
            }
        }
        return quantity;
    }

    public bool StoreItem(Item itemToStore)
    {
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

}
