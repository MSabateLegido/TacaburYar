using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemInfo
{
    [SerializeField] private NewItemType itemType;
    private string itemName;
    // Start is called before the first frame update
    public ItemInfo(NewItemType type, string name)
    {
        itemType = type;
        itemName = name;
    }

    public NewItemType GetItemType()
    {
        return itemType;
    }

    public string GetName()
    {
        return itemName;
    }

    public bool IsStackable()
    {
        return itemType == NewItemType.Crafting || itemType == NewItemType.Edible;
    }
}
