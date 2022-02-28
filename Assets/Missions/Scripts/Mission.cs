using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{

    public GameObject missionPosition;
    public float actionRadius;

    public void InitializeMission()
    {
        gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("MissionMarker").transform.position = missionPosition.transform.position;
        
    }

    private void OnEnable()
    {
        InitializeMission();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
