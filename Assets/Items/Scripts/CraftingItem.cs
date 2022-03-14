using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CraftingItemType
{
    Wood,
    Leather,
    Stone,
    Copper,
    Iron,
    DamascusSteel,
    Obsidian,
    ElementsStone
}
public class CraftingItem : Item, ICollectable
{
    private CraftingItemType craftingItemType;

    public void CollectItem()
    {
        bool stored = Player.Instance().Inventory().StoreItem(this);
        if (stored)
        {
            Destroy(gameObject);
        }
        
    }

    public CraftingItemType GetCraftingItemType()
    {
        return craftingItemType;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    
}
