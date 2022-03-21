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
    public Sprite GetItemSprite(string itemNeeded)
    {
        return namesSprites[itemNeeded];
    }
}
