using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreZone_ZoneDelimiter : MonoBehaviour
{
    public void MoveDelimiter(Vector3 position, float radius)
    {
        transform.position = position;
        transform.localScale = new Vector3(radius, 1, radius);
    }

    public void HideDelimiter()
    {
        transform.position = Vector3.zero;
    }
}
