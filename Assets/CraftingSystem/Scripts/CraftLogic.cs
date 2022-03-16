using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftLogic : MonoBehaviour
{
    private DataNeededSelector itemsNeededList;

    private CraftLogicUI userInterface;

    private CraftingDataNeeded itemsNeeded;
    private EquipmentItemType craftingItemType;
    private int itemNumber;

    private void Awake()
    {
        itemsNeededList = GetComponent<DataNeededSelector>();
        userInterface = GetComponent<CraftLogicUI>();
    }

    public void SelectEquipmentType(int type)
    {
        craftingItemType = (EquipmentItemType)type;
    }

    public void SelectItemNumber(int number)
    {
        itemNumber = number;
    }

    public void FillCraftPanel()
    {
        itemsNeeded = itemsNeededList.GetDataNeeded(craftingItemType, itemNumber);
        userInterface.FillCraftPanel(itemsNeeded);
    }

    public void CraftItem()
    {
        PlayerInventory inventory = Player.Instance().Inventory();
        if (inventory.EnoughItems(itemsNeeded))
        {
            if (inventory.EnoughSpaceInInventory())
            {
                inventory.UseItemsToCraft(itemsNeeded);
                inventory.StoreItem(itemsNeeded.GetItemToCraftPrefab());
                userInterface.ResetCraftingUserInterface();
            }
            else 
            {
                userInterface.ShowNotEnoughSpaceWarning();
            }
        }
        else
        {
            userInterface.ShowNotEnoughMaterialsWarning();
            Debug.Log("IsNotENOUGH!");
        }
        
    }
}
