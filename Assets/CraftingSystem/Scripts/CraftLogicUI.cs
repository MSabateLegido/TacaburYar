using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftLogicUI : MonoBehaviour
{
    private ItemsSpritesSelector itemsSpritesList;

    [SerializeField] Image[] itemsNeededSprites;
    [SerializeField] TextMeshProUGUI[] itemsNeededQuantities;
    [SerializeField] Image itemSprite;

    [SerializeField] TextMeshProUGUI notEnoughItemsMessage;
    [SerializeField] TextMeshProUGUI notEnoughSpaceMessage;
    private bool showingWarning = false;
    private float warningTimeLeft = 0;

    [SerializeField] BlacksmithUI blacksmithUI;

    private void Awake()
    {
        itemsSpritesList = GetComponent<ItemsSpritesSelector>();
    }

    private void Update()
    {
        if (showingWarning)
        {
            warningTimeLeft -= Time.deltaTime;
            if (warningTimeLeft <= 0)
            {
                notEnoughItemsMessage.gameObject.SetActive(false);
                notEnoughSpaceMessage.gameObject.SetActive(false);
            } 
        }
    }

    public void FillCraftPanel(CraftingDataNeeded itemsNeeded)
    {
        for (int i = 0; i < itemsNeededSprites.Length; i++)
        {
            itemsNeededSprites[i].sprite = itemsSpritesList.GetItemSprite(itemsNeeded.GetItemTypes()[i]);
            itemsNeededQuantities[i].text = itemsNeeded.GetQuantities()[i].ToString();
        }
        itemSprite.sprite = itemsNeeded.GetItemToCraftSprite();
    }

    public void ResetCraftingUserInterface()
    {
        blacksmithUI.ResetBlacksmithUI();
    }

    public void ShowNotEnoughMaterialsWarning()
    {
        showingWarning = true;
        warningTimeLeft = 3;
        notEnoughItemsMessage.gameObject.SetActive(true);
    }

    public void ShowNotEnoughSpaceWarning()
    {
        showingWarning = true;
        warningTimeLeft = 3;
        notEnoughSpaceMessage.gameObject.SetActive(true);
    }

}
