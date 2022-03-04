using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionActionObjective : MonoBehaviour
{
    [SerializeField] private string objective;


    public string GetObjective()
    {
        return objective;
    }
}
