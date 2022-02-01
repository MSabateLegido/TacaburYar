using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Villager : NonPlayableCharacter
{
    private void Awake()
    {
        
    }
    private void Update()
    {
        if (talking)
        {
            Talk();
        }
    }

    public override void Interact()
    {
        if (!talking)
        {
            StartTalking();
            base.Interact();
        }
    }

    
}
