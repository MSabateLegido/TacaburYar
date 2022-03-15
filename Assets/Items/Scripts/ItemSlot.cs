using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    private Item storedItem;
    private int quantity = 0;
    private bool empty = true;
    private int maxItemsStacked = 8;

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemQuantity;


    public void FillSlot(Item item)
    {
        empty = false;
        storedItem = item;
        itemImage.sprite = item.GetSprite();
    }

    public void AddItemToFilledSlot(int quantity)
    {
        this.quantity += quantity;
        OpenOrCloseQuantityTextIfNeeded();
    }

    public bool HasStored(Item item)
    {
        return storedItem == item;
    }

    /*
     * 
     * ##############
     * OLD CODE
     * ##############
     * 
     */


    public void FillEmptySlot(Item item, int quantity)
    {
        storedItem = item;
        this.quantity = quantity;
        empty = false;
        itemImage.sprite = item.GetSprite();
        OpenOrCloseQuantityTextIfNeeded();
    }

    private void OpenOrCloseQuantityTextIfNeeded()
    {
        if (this.quantity > 1)
        {
            itemQuantity.gameObject.SetActive(true);
            itemQuantity.text = quantity.ToString();
        } 
        else
        {
            itemQuantity.gameObject.SetActive(false);
        }
    }

    public bool IsEmpty()
    {
        return empty;
    }

    public ItemType GetStoredItemType()
    {
        return storedItem.GetItemType();
    }

    public bool SlotFull()
    {
        return quantity >= maxItemsStacked;
    }

    public void EmptySlot()
    {
        storedItem = null;
        quantity = 0;
        empty = true;
        itemImage.sprite = null;
        OpenOrCloseQuantityTextIfNeeded();
    }

    public void OnClick()
    {
        if (storedItem?.GetItemType() == ItemType.EquipmentItem)
        {
            EquipmentItem itemToEquip = (EquipmentItem)storedItem;
            EmptySlot();
            Player.Instance().Inventory().ChangeEquipmentItem(itemToEquip);
            //ARREGLAR
        }
    }

    public int MinusItemQuantity(int quantityToMinus)
    {
        if (quantityToMinus >= this.quantity)
        {
            quantityToMinus -= this.quantity;
            EmptySlot();
        }
        else
        {
            this.quantity -= quantityToMinus;
            quantityToMinus = 0;
            OpenOrCloseQuantityTextIfNeeded();
        }
        Debug.Log(quantityToMinus);
        return quantityToMinus;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    private void EquipItemAndStoreEquiped()
    {

    }
}
