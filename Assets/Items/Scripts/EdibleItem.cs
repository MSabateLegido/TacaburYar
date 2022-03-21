using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EatEvent : UnityEvent<EdibleItem> { }
public class EdibleItem : Item, IEdible, ICollectable
{
    public static EatEvent onEatEdibleItem;
    [Range(0, 0.3f)]
    [SerializeField] private float hungerRecoveryPercent;
    void Awake()
    {
        LazyInitializeOnAcquireItem();
        InitializeItemInfo();
    }

    protected override void InitializeItemInfo()
    {
        itemInfo = new ItemInfo(ItemType.Edible, gameObject.tag);
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

    public void EatItem()
    {
        onEatEdibleItem.Invoke(this);
    }

    public static void LazyInitializeEatEvent()
    {
        if (onEatEdibleItem == null)
        {
            onEatEdibleItem = new EatEvent();
        }
    }

    public float GetHungerRecovery()
    {
        return hungerRecoveryPercent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }
}
