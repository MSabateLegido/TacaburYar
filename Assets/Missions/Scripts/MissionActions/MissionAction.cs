using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissionAction : MonoBehaviour
{
    [SerializeField] private string objective;


    public string GetObjective() { return objective; }
    public virtual void CompleteAction()
    {
        GetComponentInParent<Mission>().CompleteAction();
    }
}
