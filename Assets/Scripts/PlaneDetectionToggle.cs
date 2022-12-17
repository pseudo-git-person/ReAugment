using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class PlaneDetectionToggle : MonoBehaviour
{
    private ARPlaneManager planeManager;
    
    [SerializeField]
    private Text toggleButtonText;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        toggleButtonText.text = "Hide Planes";
    }

    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;       //planeManager changes state
        string ToggleButtonMessage = "";

        if(planeManager.enabled)
        {
            ToggleButtonMessage = "Hide Planes";
            SetAllPlanesActive(true);
        }
        else
        {
            ToggleButtonMessage = "Show Planes";
            SetAllPlanesActive(false);
        }

        toggleButtonText.text = ToggleButtonMessage;

    }

    public void SetAllPlanesActive(bool value)
    {
        foreach(var plane in planeManager.trackables)       //set the value of each plane stored by planeManager based on the button state
        {
            plane.gameObject.SetActive(value);
        }
    }

}
