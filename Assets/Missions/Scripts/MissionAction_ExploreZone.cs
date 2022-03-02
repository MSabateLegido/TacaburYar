using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAction_ExploreZone : MissionAction
{
    [SerializeField] private Transform zoneCenter;
    [SerializeField] private float zoneRadius;
    private ExploreZone_ZoneDelimiter delimiter;
    private void OnEnable()
    {
        delimiter = GameObject.FindGameObjectWithTag("ZoneMarker").GetComponent<ExploreZone_ZoneDelimiter>();
        delimiter.MoveDelimiter(zoneCenter.position, zoneRadius);
    }

    public override void CompleteAction()
    {
        delimiter.HideDelimiter();
        base.CompleteAction();
    }

}
