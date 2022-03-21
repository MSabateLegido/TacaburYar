using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAction_ReachPoint : MissionAction
{
    private PointMarker marker;
    [SerializeField]private Transform point;
    private void OnEnable()
    {
        marker = GameObject.FindGameObjectWithTag("PointMarker").GetComponent<PointMarker>();
        marker.SetPointMarker(point);
    }

    public override void CompleteAction()
    {
        marker.HideMarker();
        base.CompleteAction();
    }
}
