using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneDelimiter : MonoBehaviour
{
    private Transform markerPosition;
    private bool hided = true;
    private void Update()
    {
        if (!hided) 
        {
            transform.position = markerPosition.position;
        }
    }
    public void MoveDelimiter(Transform position, float radius)
    {
        hided = false;
        markerPosition = position; 
        transform.localScale = new Vector3(radius, 1, radius);
    }

    public void HideDelimiter()
    {
        hided = true;
        transform.position = Vector3.zero;
    }
}
