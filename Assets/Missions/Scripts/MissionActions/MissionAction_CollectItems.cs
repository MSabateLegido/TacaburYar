using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAction_CollectItems : MissionAction
{
    [SerializeField] private ItemType itemTypeToCollect;
    [SerializeField] private string itemNameToCollect;

    [SerializeField] int CollectionsToComplete;
    int currentCollections;

    private void Start()
    { 
        Item.onAcquireItem.AddListener(OnCollectItem);
        currentCollections = 0;
    }

    private void OnCollectItem(Item item)
    {
        if (CheckItem(item))
        {
            currentCollections++;
            Debug.Log(currentCollections);
            if (currentCollections == CollectionsToComplete)
            {
                CompleteAction();
            }
        }
    }

    public override void CompleteAction()
    {
        Item.onAcquireItem.RemoveListener(OnCollectItem);
        base.CompleteAction();
    }

    private bool CheckItem(Item item)
    {
        return item.GetItemType() == itemTypeToCollect && item.GetItemName().Equals(itemNameToCollect);
    }
}
