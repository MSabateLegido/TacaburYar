using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType //Edible, crafting, equipment
{
    Crafting,
    Edible,
    Potion,
    Equipment
}
public class Item : MonoBehaviour
{

    [SerializeField] protected ItemType type;
    [SerializeField] protected Sprite itemSprite;

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
}
