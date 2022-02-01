using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItemSlot : MonoBehaviour
{

    private bool equiped;

    [SerializeField] private Image itemImage;

    public void SetSlotToDefault()
    {
        itemImage.gameObject.SetActive(false);
        equiped = false;
    }

    public void ChangeEquipmentImage(Sprite newItemSprite)
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = newItemSprite;
        equiped = true;
    }

    public bool isEquiped()
    {
        return equiped;
    }
}
