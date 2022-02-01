using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAtPlayer : MonoBehaviour
{
    private Transform playerToLookAt;
    private bool looking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (looking)
        {
            transform.LookAt(playerToLookAt.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            looking = true;
            playerToLookAt = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            looking = false;
        }
    }
}
