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

    [SerializeField] private CraftingItemType craftingType;
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

    public CraftingItemType GetCraftingItemType()
    {
        return craftingType;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    
}
