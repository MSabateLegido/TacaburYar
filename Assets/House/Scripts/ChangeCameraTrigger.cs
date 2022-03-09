using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraTrigger : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook mainCamera;
    [SerializeField] CinemachineVirtualCamera otherCamera;

    private void OnTriggerEnter(Collider other)
    {
        otherCamera.Priority += 5;
        mainCamera.Priority -= 5;

    }

    private void OnTriggerExit(Collider other)
    {
        mainCamera.Priority += 5;
        otherCamera.Priority -= 5;
    }
    
}
