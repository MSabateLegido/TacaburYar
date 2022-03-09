using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blacksmith : NonPlayableCharacter
{
    [SerializeField] BlacksmithUI blacksmithUI;

    private bool alreadyInteracted = false;

    private void Update()
    {
        if (talking)
        {
            Talk();
        }
    }

    public override void Interact()
    {
        if (alreadyInteracted)
        {
            if (!talking)
            {
                
                if (playerInteracting)
                {
                    blacksmithUI.OpenBlacksmithUI();
                    interactButtonImage.SetActive(false);
                }
                else
                {
                    blacksmithUI.CloseBlacksmithUI();
                    interactButtonImage.SetActive(true);
                }
            }
        }
        else
        {
            StartTalking();
            alreadyInteracted = true;
        }
        base.Interact();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactButtonImage.SetActive(false);
            blacksmithUI.CloseBlacksmithUI();
            //Player.Instance().StopInteracting();
        }
    }
}
