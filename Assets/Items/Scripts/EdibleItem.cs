using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleItem : Item, ICollectable, IEdible
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectItem()
    {
        bool stored = Player.Instance().Inventory().StoreItem(this);
        if (stored)
        {
            Destroy(gameObject);
        }
    }
    public void EatItem()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }
}
