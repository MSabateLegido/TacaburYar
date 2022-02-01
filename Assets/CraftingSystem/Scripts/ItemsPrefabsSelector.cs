using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPrefabsSelector : MonoBehaviour
{
    [SerializeField] EquipmentItem[] itemsPrefabs;

    public EquipmentItem GetCraftedItemPrefab(EquipmentItemType equipmentType, int itemIndex)
    {
        string itemName = EquipmentItem.GetEquipmentItemTypeString(equipmentType) + itemIndex;
        EquipmentItem auxEquipmentItem = null;
        foreach (EquipmentItem item in itemsPrefabs)
        {
            if (item.name.Equals(itemName))
            {
                auxEquipmentItem = item;
            }
        }
        return auxEquipmentItem;
    }
}
