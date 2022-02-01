using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWeapon : MonoBehaviour
{
    [SerializeField] Sword[] swords;

    private Sword currentSword;


    private void Start()
    {
        currentSword = swords[0];
        Invoke(nameof(changeWeaponTest), 5f);
    }

    public void changeWeapon(int swordIndex)
    {
        currentSword.gameObject.SetActive(false);
        currentSword = swords[swordIndex];
        currentSword.gameObject.SetActive(true);
    }

    public void changeWeaponTest()
    {
        currentSword.gameObject.SetActive(false);
        currentSword = swords[2];
        currentSword.gameObject.SetActive(true);
    }

    public Stats GetStats()
    {
        return currentSword.GetStats();
    }

}
