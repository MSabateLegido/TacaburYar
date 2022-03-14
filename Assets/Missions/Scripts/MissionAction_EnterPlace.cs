using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAction_EnterPlace : MissionAction
{

    [SerializeField]private Transform placeToEnter;
    //Marker that place in front of the place;
    private PointMarker marker;

    private void OnEnable()
    {
        marker = GameObject.FindGameObjectWithTag("PointMarker").GetComponent<PointMarker>();
        marker.SetMarkerPosition(placeToEnter);
    }

    public override void CompleteAction()
    {
        marker.HideMarker();
        base.CompleteAction();
    }
}
