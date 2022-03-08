using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject inventoryCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnOpenInventory()
    {
        inventoryCamera.SetActive(!inventoryCamera.activeSelf);
    }
}
