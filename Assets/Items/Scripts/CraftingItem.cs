using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingItem : Item, ICollectable
{

    private void Awake()
    {
        InitializeItemInfo();
    }

    protected override void InitializeItemInfo()
    {
        itemInfo = new ItemInfo(ItemType.Crafting, gameObject.tag);
    }

    public void CollectItem()
    {
        if (Player.Instance().Inventory().EnoughSpaceInInventory())
        {
            Player.Instance().Inventory().StoreItem(this);
            onAcquireItem.Invoke(this);
            Destroy(gameObject);
        }
        else
        {
            //Cant collect;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    
}
