using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataNeededSelector : MonoBehaviour
{
    [SerializeField] private CraftingDataNeeded[] craftingItemsNeeded; 

    public CraftingDataNeeded GetDataNeeded(EquipmentItemType equipmentType, int itemIndex)
    {
        string itemName = EquipmentItem.GetEquipmentItemTypeString(equipmentType) + itemIndex;
        CraftingDataNeeded auxItemsNeeded = null;
        foreach (CraftingDataNeeded itemsNeeded in craftingItemsNeeded)
        {
            if (itemsNeeded.name.Equals(itemName))
            {
                auxItemsNeeded = itemsNeeded;
            }
        }
        return auxItemsNeeded;
    }

    public void RecieveData(List<CraftingDataNeeded> itemsNeededList)
    {
        craftingItemsNeeded = itemsNeededList.ToArray();
        if (craftingItemsNeeded.Length >= 0)
        {
            Debug.Log("Found " + craftingItemsNeeded.Length + " objects");
        }
        else
        {
            Debug.Log("Can't do that");
        }
    }
}
