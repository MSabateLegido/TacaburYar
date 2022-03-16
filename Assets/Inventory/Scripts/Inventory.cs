using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //NEW
    private List<Item> storedItems;
    private int slotsAvailable;
    private InventoryUI userInterface;
    private int maxStack = 20;
    //

    private ItemSlot[] itemSlots;


    public void Awake()
    {
        storedItems = new List<Item>();
        slotsAvailable = 15;
        userInterface = GetComponent<InventoryUI>();
        itemSlots = GetComponentsInChildren<ItemSlot>();   
    }

    private void Start()
    {
        userInterface.AddOnEmptySlotListeners(OnEmptySlot);
    }

    public void TryStoreItem(Item item)
    {
        if (item.IsStackable())
        {
            if (ExistsInInventory(item))
            {
                //falta comprobar si el stack esta ple
                StoreItem(item, true);
            }
            else
            {
                StoreItemIfSlotsAvailable(item);
            }
        }
        else
        {
            StoreItemIfSlotsAvailable(item);
        }
    }

    private void StoreItemIfSlotsAvailable(Item item)
    {
        if (slotsAvailable > 0)
        {
            StoreItem(item, false);
        }
        else
        {
            //Tirar item a terra
        }
    }

    private bool ExistsInInventory(Item item)
    {
        bool exist = false;
        int i = 0;
        while (!exist && i < storedItems.Count)
        {
            if (item.Equals(storedItems[i]))
            {
                exist = true;
            }
            i++;

        }
        return exist;
    }

    private void StoreItem(Item item, bool stacked)
    {
        storedItems.Add(item);
        userInterface.StoreItem(item, stacked);
        if (!stacked) slotsAvailable--;
    }

    public bool EnoughSpaceInInventory()
    {
        return slotsAvailable > 0;
    }

    private void OnEmptySlot()
    {
        slotsAvailable++;
    }

    public List<Item> GetStoredItems()
    {
        return storedItems;
    }
}
