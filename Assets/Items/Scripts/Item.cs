using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    Wood,
    Leather,
    Stone,
    Copper,
    Iron,
    DamascusSteel,
    Obsidian,
    ElementsStone,
    EquipmentItem
}

public enum NewItemType
{
    Crafting,
    Potion, 
    Edible,
    Equipment
}
public class Item : MonoBehaviour
{
    protected ItemType type;
    [SerializeField] protected ItemInfo itemInfo;
    [SerializeField] protected NewItemType newType;
    [SerializeField] protected Sprite itemSprite;


    
    public NewItemType NewGetItemType()
    {
        return itemInfo.GetItemType();
    }
    public ItemType GetItemType()
    {
        return type;
    }

    public Sprite GetSprite()
    {
        return itemSprite;
    }

    public static int GetItemTypesCount()
    {
        return Enum.GetNames(typeof(ItemType)).Length;
    }

    public static string GetItemTypeString(ItemType type)
    {
        return Enum.GetNames(typeof(ItemType))[(int)type];
    }

    public string GetItemName()
    {
        return itemInfo.GetName();
    }


    public bool IsStackable()
    {
        return itemInfo.IsStackable();
    }

    public bool IsCraftingItem()
    {
        return itemInfo.GetItemType() == NewItemType.Crafting;
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
}
