using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;


public class Player : MonoBehaviour
{
    public static int NON_HITABLE_LAYER = 8;
    public static int DEFAULT_LAYER = 0;
    private static Player instance;

    public static Player Instance()
    {
        return instance;
    }

    
    [SerializeField] Camera playerCamera;
    private PlayerEquipmentSet equipment;
    private PlayerInventory inventory;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private PlayerStats playerStats;
    private PlayerAnimation playerAnimations;
    private PlayerLevel playerLevel;
    private PlayerUI playerUI;




    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimations = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<PlayerStats>();
        playerLevel = GetComponent<PlayerLevel>();
        playerUI = GetComponent<PlayerUI>();
        inventory = GetComponent<PlayerInventory>();
        equipment = GetComponentInChildren<PlayerEquipmentSet>();
        instance = this;
    }

    public PlayerMovement Movement()
    {
        return playerMovement;
    }

    public PlayerAttack Attack()
    {
        return playerAttack;
    }

    public PlayerEquipmentSet Equipment()
    {
        return equipment;
    }

    public PlayerStats Stats()
    {
        return playerStats;
    }

    public PlayerAnimation Animations()
    {
        return playerAnimations;
    }

    public PlayerLevel Level()
    {
        return playerLevel;
    }

    public PlayerUI UserInterface()
    {
        return playerUI;
    }

    public PlayerInventory Inventory()
    {
        return inventory;   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
