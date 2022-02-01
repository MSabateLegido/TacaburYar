using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/VillagerMessages", order = 1)]
public class VillagerMessage : ScriptableObject
{
    [SerializeField] private string[] messages;


    public string GetMessage(int index)
    {
        return messages[index];
    }

    public bool MessageExists(int index)
    {
        return index < messages.Length ;
    }
}
