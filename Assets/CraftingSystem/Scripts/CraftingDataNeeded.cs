using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CraftingItemsNeeded", order = 1)]
public class CraftingDataNeeded : ScriptableObject
{

    [SerializeField] Sprite itemToCraftSprite;
    [SerializeField] EquipmentItem itemToCraftPrefab;

    [SerializeField] string[] items;
    [SerializeField] int[] itemsQuantity;

    public string[] GetItemTypes()
    {
        return items;
    }

    public int[] GetQuantities()
    {
        return itemsQuantity;
    }

    public Sprite GetItemToCraftSprite()
    {
        return itemToCraftSprite;
    }

    public EquipmentItem GetItemToCraftPrefab()
    {
        return itemToCraftPrefab;
    }

}
