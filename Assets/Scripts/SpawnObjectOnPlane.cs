using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;      //
using UnityEngine.XR.ARSubsystems;      // XR Libraries required


[RequireComponent(typeof(ARRaycastManager))]
public class SpawnObjectOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    //private variable  with modification available in the interface
    [SerializeField]
    private GameObject PlaceablePrefab;

    //list storing hits by Raycast
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    //Initial reference for the RaycastManager, as to make sure it is not null 
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    //function recording where the user is pressing on the screen
    //if input is received return true and store the position in touchPosition variiable
    //if not return false
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    //On update check whether there is a valid touch position
    //if not return
    //if yes use Raycast and check whether it is hitting a trackable plane with .Raycast using touchPosition recorded Hits 
    private void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;     //hit position variable
            if(spawnedObject == null)       //if there is no object spawned instantiate an object with position and rotation of the hitPose
            {
                spawnedObject = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);
            }
            else                            //if there is an Object placed already do not instantiate, transform position and rotation instead
            {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }
        }
    }
    //Instead of transforming an instantiated object I might create a list of objects so it will be possible to place multiple objects, not just one
}
