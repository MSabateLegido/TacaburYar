using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public BoolEvent onOpenInventory;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject inventoryCamera;

    [SerializeField] EquipmentItem itemToStore;

    private void Awake()
    {
        onOpenInventory = new BoolEvent();
    }

    private void Start()
    {
        Player.Instance().Equipment().onEquipmentUnequiped.AddListener(StoreItem);
        StoreItem(itemToStore);
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

    private int CountItemsOfType(string type)
    {
        int quantity = 0;
        foreach (Item item in inventory.GetStoredItems())
        {
            if (item.GetItemName().Equals(type))
            {
                quantity++;
            }
        }
        return quantity;
    }


    public void UseItemsToCraft(CraftingDataNeeded itemsNeeded)
    {
        for (int i = 0; i < itemsNeeded.GetItemTypes().Length; i++)
        {
            UseItems(itemsNeeded.GetItemTypes()[i], itemsNeeded.GetQuantities()[i]);
        }
    }

    private void UseItems(string type, int quantity)
    {
        int quantityLeft = quantity;
        //TODO
    }

    public void StoreItem(Item item)
    {
        inventory.TryStoreItem(item);
    }

    public void OpenCloseInventory()
    {
        inventoryCamera.SetActive(!inventoryCamera.activeSelf);
        onOpenInventory.Invoke(inventoryCamera.activeSelf);
    }


    public bool EnoughSpaceInInventory()
    {
        return inventory.EnoughSpaceInInventory();
    }

    private void OnOpenInventory()
    {
        OpenCloseInventory();
    }
    
}
