using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpritesSelector : MonoBehaviour
{
    [SerializeField] Sprite[] itemsSprites;
    [SerializeField] string[] itemsNames;

    private Dictionary<string, Sprite> namesSprites;

    private void Start()
    {
        for (int i = 0; i < itemsSprites.Length; i++)
        {
            namesSprites.Add(itemsNames[i], itemsSprites[i]);
        }
    }
    public Sprite[] GetItemsNeededSprites(ItemType[] itemsNeeded)
    {
        return new[] { itemsSprites[(int)itemsNeeded[0]], itemsSprites[(int)itemsNeeded[1]], itemsSprites[(int)itemsNeeded[2]] };
    }

    public Sprite GetItemSprite(string itemNeeded)
    {
        return namesSprites[itemNeeded];
    }
}
