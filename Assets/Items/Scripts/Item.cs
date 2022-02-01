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
