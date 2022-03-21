using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemInfo
{
    private ItemType itemType;
    private string itemName;
    // Start is called before the first frame update
    public ItemInfo() {}

    public ItemInfo(ItemType type, string name)
    {
        itemType = type;
        itemName = name;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public string GetName()
    {
        return itemName;
    }

    public bool IsStackable()
    {
        return itemType == ItemType.Crafting || itemType == ItemType.Edible;
    }
}
