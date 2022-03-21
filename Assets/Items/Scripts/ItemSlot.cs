using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public UnityEvent onEmptySlot;
    private Item storedItem;
    private int quantity = 0;
    private bool empty = true;

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemQuantity;


    public void FillSlot(Item item)
    {
        empty = false;
        storedItem = item;
        quantity = 1;
        itemImage.sprite = item.GetSprite();
    }

    public void AddItemToFilledSlot(int quantity)
    {
        this.quantity += quantity;
        UpdateQuantityText();
    }

    public bool HasStored(Item item)
    {
        return storedItem.Equals(item);
    }

    public void AddOnEmptySlotListener(UnityAction action)
    {
        onEmptySlot.AddListener(action);
    }

    private void UpdateQuantityText()
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

    public void EmptySlot()
    {
        storedItem = null;
        quantity = 0;
        empty = true;
        itemImage.sprite = null;
        UpdateQuantityText();
        onEmptySlot.Invoke();
    }

    public void OnClick()
    {
        if (storedItem?.GetItemType() == ItemType.Equipment)
        {
            EquipmentItem itemToEquip = (EquipmentItem)storedItem;
            EmptySlot();
            Player.Instance().Equipment().ChangeEquipmentItem(itemToEquip);
            //ARREGLAR
        }
        else if (storedItem?.GetItemType() == ItemType.Edible)
        {
            ((EdibleItem)storedItem).EatItem();
            quantity--;
            if (quantity == 0) EmptySlot();
            else UpdateQuantityText();
        }
    }
}
