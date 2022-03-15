using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public BoolEvent onOpenInventory;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject inventoryCamera;
    // Start is called before the first frame update

    private void Awake()
    {
        onOpenInventory = new BoolEvent();
    }

    public void ChangeEquipmentItem(EquipmentItem newEquipment)
    {
        EquipmentItem itemToStore = Player.Instance().Equipment().EquipNewItemAndReturnCurrent(newEquipment);
        if (itemToStore != null)
        {
            inventory.OldStoreItem(itemToStore);
        }
    }

    public void UnequipItem(EquipmentItem unequipedItem)
    {
        inventory.OldStoreItem(unequipedItem);
        Player.Instance().Stats().UpdatePlayerStats();
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
    private void OnOpenInventory()
    {
        OpenCloseInventory();
    }
    
}
