using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpritesSelector : MonoBehaviour
{
    [SerializeField] Sprite[] itemsSprites;

    public Sprite[] GetItemsNeededSprites(CraftingItemType[] itemsNeeded)
    {
        return new[] { itemsSprites[(int)itemsNeeded[0]], itemsSprites[(int)itemsNeeded[1]], itemsSprites[(int)itemsNeeded[2]] };
    }

    public Sprite GetItemSprite(CraftingItemType itemNeeded)
    {
        return itemsSprites[(int)itemNeeded];
    }
}
