using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissionAction : MonoBehaviour
{


    public virtual void CompleteAction()
    {
        GetComponentInParent<Mission>().CompleteAction();
    }
}
