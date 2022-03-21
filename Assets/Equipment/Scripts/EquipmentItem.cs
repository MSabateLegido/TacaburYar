using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentItemType
{
    Shield,
    Sword,
    Helmet,
    Shoulders,
    Armor,
    Belt,
    Gloves,
    Boots
}
public class EquipmentItem : Item
{
    [SerializeField] protected StatsScriptableObject itemStats;
    [SerializeField] protected int itemIndex;

    private void Awake()
    {
        InitializeItemInfo();
    }

    protected override void InitializeItemInfo()
    {
        itemInfo = new ItemInfo(ItemType.Equipment, gameObject.tag + itemIndex);
    }

    public int GetItemIndex()
    {
        return itemIndex;
    }

    public Stats GetStats()
    {
        return itemStats.GetStats();
    }

    public static string GetEquipmentItemTypeString(EquipmentItemType type)
    {
        return Enum.GetNames(typeof(EquipmentItemType))[(int)type];
    }
}
