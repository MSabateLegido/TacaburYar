using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectable : Item, Collectable
{

    public void CollectItem(Inventory inventory)
    {
        bool stored = inventory.StoreItem(this);
        if (stored)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem(other.GetComponent<Inventory>());
        }
    }

    
}
