using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneDelimiter : MonoBehaviour
{
    private Transform center;
    private float radius;
    bool hided = true;

    private void Update()
    {
        if (!hided)
        {
            MoveDelimiter();        
        }
    }

    public void SetDelimiter(Transform centerPosition, float auxRadius)
    {
        hided = false;
        center = centerPosition;
        radius = auxRadius;
    }

    void MoveDelimiter()
    {
        transform.position = center.position;
        transform.localScale = new Vector3(radius, 1, radius);
    }
    public void HideDelimiter()
    {
        hided = true;
        transform.position = Vector3.zero;
    }
}
