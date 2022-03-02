using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissionAction : MonoBehaviour
{
    private MissionActionObjective objective;

    public virtual void CompleteAction()
    {
        GetComponentInParent<Mission>().CompleteAction();
    }
}
