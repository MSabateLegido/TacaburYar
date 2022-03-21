using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : MonoBehaviour
{
    [SerializeField] private bool fullScreen;

    public string GetName()
    {
        return gameObject.tag;
    }

    public bool IsFullScreen()
    {
        return fullScreen;
    }

    public void ActiveMenu(bool active)
    {
        gameObject.SetActive(active);
    }
}
