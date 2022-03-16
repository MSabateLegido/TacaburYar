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
    [SerializeField] protected EquipmentItemType equipmentItemType;
    [SerializeField] protected StatsScriptableObject itemStats;
    [SerializeField] protected int itemIndex;

    private void Awake()
    {
        Debug.Log("Hola soc equipment item");
        itemInfo = new ItemInfo(NewItemType.Equipment, gameObject.tag);
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
        return itemStats.GetStats();
    }

    public static string GetEquipmentItemTypeString(EquipmentItemType type)
    {
        return Enum.GetNames(typeof(EquipmentItemType))[(int)type];
    }
}
