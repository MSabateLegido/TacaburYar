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



    public void Awake()
    {
        storedItems = new List<Item>();
        slotsAvailable = 15;
        userInterface = GetComponent<InventoryUI>();
    }

    private void Start()
    {
        userInterface.AddOnEmptySlotListeners(OnEmptySlot);
        EdibleItem.LazyInitializeEatEvent();
        EdibleItem.onEatEdibleItem.AddListener(OnEatEdibleItem);
    }

    public void TryStoreItem(Item item)
    {
        if (item.IsStackable())
        {
            if (ExistsInInventory(item))
            {
                if (CountItemsOfType(item.GetItemName()) < maxStack)
                {
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

    public int CountItemsOfType(string type)
    {
        int quantity = 0;
        foreach (Item item in storedItems)
        {
            if (item.GetItemName().Equals(type))
            {
                quantity++;
            }
        }
        return quantity;
    }

    public bool EnoughSpaceInInventory()
    {
        return slotsAvailable > 0;
    }

    private void OnEmptySlot()
    {
        slotsAvailable++;
    }

    private void OnEatEdibleItem(EdibleItem itemEated)
    {
        Debug.Log(storedItems.Count);
        storedItems.Remove(itemEated);
        Debug.Log(storedItems.Count);
    }

    public List<Item> GetStoredItems()
    {
        return storedItems;
    }
}
