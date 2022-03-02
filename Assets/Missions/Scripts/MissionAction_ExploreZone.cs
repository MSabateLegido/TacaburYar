using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAction_ExploreZone : MissionAction
{
    [SerializeField] private Transform zoneCenter;
    [SerializeField] private float zoneRadius;

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("ZoneMarker").GetComponent<ExploreZone_ZoneDelimiter>().MoveDelimiter(zoneCenter.position, zoneRadius);
    }

    public override void CompleteAction()
    {
        GameObject.FindGameObjectWithTag("ZoneMarker").GetComponent<ExploreZone_ZoneDelimiter>().HideDelimiter();
        base.CompleteAction();
    }

}
