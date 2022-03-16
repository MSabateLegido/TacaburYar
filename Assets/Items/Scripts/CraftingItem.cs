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

    private void Awake()
    {
        itemInfo = new ItemInfo(NewItemType.Crafting, gameObject.tag);
    }

    public void CollectItem()
    {
        Player.Instance().Inventory().StoreItem(this);
        Destroy(gameObject);
        /*bool stored = inventory.OldStoreItem(this);
        if (stored)
        {
            Destroy(gameObject);
        }*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    
}
