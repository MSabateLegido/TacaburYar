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
    private Inventory inventory;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private PlayerStats playerStats;
    private PlayerAnimation playerAnimations;
    private PlayerLevel playerLevel;
    private PlayerUI playerUI;

    private bool moving = false;

    private bool lookingInventory = false;
    private bool interacting = false;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimations = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<PlayerStats>();
        playerLevel = GetComponent<PlayerLevel>();
        playerUI = GetComponent<PlayerUI>();
        inventory = GetComponent<Inventory>();
        equipment = GetComponentInChildren<PlayerEquipmentSet>();
        instance = this;
    }

    private void Start()
    {

    }

    

    public void ChangeEquipmentItem(EquipmentItem newEquipment)
    {
        EquipmentItem itemToStore = equipment.EquipNewItemAndReturnCurrent(newEquipment);
        if (itemToStore != null)
        {
            inventory.StoreItem(itemToStore);
        }
    }

    public void UnequipItem(EquipmentItem unequipedItem)
    {
        inventory.StoreItem(unequipedItem);
        playerStats.UpdatePlayerStats();
    }

    void OnOpenInventory()
    {
        if (!interacting)
        {
            lookingInventory = !lookingInventory;
            inventory.OpenOrCloseInventory(lookingInventory);
            equipment.OpenOrCloseEquipmentUI(lookingInventory);
            playerMovement.SetMovement(!lookingInventory);
        }
    }

    private void OnInteract()
    {
        if (!lookingInventory)
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position, 1);
            foreach (Collider col in collisions)
            {
                if (col.CompareTag("NPC"))
                {
                    col.GetComponent<NonPlayableCharacter>().Interact();
                }
            }
        }
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

    public Inventory Inventory()
    {
        return inventory;   
    }

    public void StartInteracting()
    {
        interacting = true;
        playerMovement.SetMovement(false);
    }

    public void StopInteracting()
    {
        interacting = false;
        playerMovement.SetMovement(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }

}
