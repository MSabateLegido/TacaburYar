using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMarker : MonoBehaviour
{
    private Transform point;
    private bool hided = true;

    private void Update()
    {
        if (!hided)
        {
            transform.position = point.position;
        }
    }
    public void SetMarkerPosition(Transform position)
    {
        hided = false;
        point = position;
    }

    public void HideMarker()
    {
        hided = true;
        transform.position = Vector3.zero;
    }
}
