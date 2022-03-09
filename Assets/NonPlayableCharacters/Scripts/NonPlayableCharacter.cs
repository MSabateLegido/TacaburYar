using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NonPlayableCharacter : MonoBehaviour
{
    [SerializeField] protected GameObject interactButtonImage;
    protected bool playerInteracting = false;

    [SerializeField] protected GameObject messagePanel;
    [SerializeField] protected GameObject nextImage;
    [SerializeField] protected TextMeshProUGUI messageBox;
    [SerializeField] protected VillagerMessage messages;
    protected int currentMessageIndex = 0;
    protected bool talking = false;
    protected string currentMessage;

    protected float timeBetweenLetters = 0.05f;
    protected float timeSinceLastLetter = 0;

    public virtual void Interact()
    {
        playerInteracting = !playerInteracting;
        if (playerInteracting)
        {
            //Player.Instance().StartInteracting();
        }
        else
        {
            //Player.Instance().StopInteracting();
        }
        
    }

    protected void Talk()
    {
        if (currentMessage.Length == 0)
        {
            nextImage.SetActive(true);
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                nextImage.SetActive(false);
                ++currentMessageIndex;
                if (messages.MessageExists(currentMessageIndex))
                {
                    messageBox.text = "";
                    currentMessage = messages.GetMessage(currentMessageIndex);
                }
                else
                {
                    talking = false;
                    messagePanel.gameObject.SetActive(false);
                    currentMessageIndex = 0;
                    currentMessage = messages.GetMessage(currentMessageIndex);
                    //Player.Instance().StopInteracting();
                }
            }
        }
        else
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                messageBox.text += currentMessage;
                currentMessage = "";
                timeSinceLastLetter = 0;
            }
            timeSinceLastLetter += Time.deltaTime;
            if (timeSinceLastLetter >= timeBetweenLetters)
            {
                messageBox.text += currentMessage[0];
                currentMessage = currentMessage.Substring(1);
                timeSinceLastLetter = 0;
            }
        }
    }

    protected void StartTalking()
    {
        currentMessage = messages.GetMessage(0);
        messagePanel.gameObject.SetActive(true);
        talking = true;
        messageBox.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactButtonImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactButtonImage.SetActive(false);
        }
    }
}
