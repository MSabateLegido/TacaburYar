using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public enum ItemType
{
    Crafting,
    Potion, 
    Edible,
    Equipment
}

public class ItemEvent : UnityEvent<Item> { }
public class Item : MonoBehaviour
{
    public static ItemEvent onAcquireItem;
    protected ItemInfo itemInfo;
    [SerializeField] protected Sprite itemSprite;

    
    public ItemType GetItemType()
    {
        return itemInfo.GetItemType();
    }


    public Sprite GetSprite()
    {
        return itemSprite;
    }

    public string GetItemName()
    {
        return itemInfo.GetName();
    }


    public bool IsStackable()
    {
        LazyInitializeItemInfo();
        return itemInfo.IsStackable();
    }

    public bool IsCraftingItem()
    {
        return itemInfo.GetItemType() == ItemType.Crafting;
    }

    public override bool Equals(object other)
    {
        Item otherItem = other as Item;
        if (GetItemName().Equals(otherItem.GetItemName()))
        {
            return true;
        }
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private void LazyInitializeItemInfo()
    {
        if (itemInfo == null)
        {
            InitializeItemInfo();
        }
    }

    protected virtual void InitializeItemInfo()
    {
        itemInfo = new ItemInfo();
    }

    protected void LazyInitializeOnAcquireItem()
    {
        if (onAcquireItem == null)
        {
            onAcquireItem = new ItemEvent();
        }
    }
}
