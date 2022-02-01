using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentItemType
{
    Helmet,
    Shoulders,
    Armor,
    Sword,
    Shield,
    Belt,
    Gloves,
    Boots
}
public class EquipmentItem : Item
{

    [SerializeField] protected EquipmentItemType equipmentItemType;
    [SerializeField] protected Stats itemStats;
    [SerializeField] protected int itemIndex;

    protected void DefaultEquipmentItemSetup()
    {
        type = ItemType.EquipmentItem;
    }

    public EquipmentItemType GetEquipmentType()
    {
        return equipmentItemType;
    }

    public int GetItemIndex()
    {
        return itemIndex;
    }

    public Stats GetStats()
    {
        return itemStats;
    }

    public static string GetEquipmentItemTypeString(EquipmentItemType type)
    {
        return Enum.GetNames(typeof(EquipmentItemType))[(int)type];
    }
}
