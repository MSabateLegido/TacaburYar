using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAction_ExploreZone : MissionAction
{
    [SerializeField] private Transform zoneCenter;
    [SerializeField] private float zoneRadius;
    private ZoneMarker zoneMarker;
    private void Start()
    {
        zoneMarker = GameObject.FindGameObjectWithTag("ZoneMarker").GetComponent<ZoneMarker>();
    }
}
