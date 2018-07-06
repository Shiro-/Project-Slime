using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    //public GameObject trigger;
    public Transform cameraPosition;
    public Transform cameraZoomPosition;

    private Collider playerCollider;
    private Collider triggerCollider;

    private Vector3 offset;
    private Vector3 previousPlayerPosition;

    private float playerHeightThreshold;

    public float zoomSpeed;

    //private bool isColliding;

    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        //triggerCollider = trigger.GetComponent<Collider>();

        //Used so we can move the camera along the x axis only
        offset = transform.position - player.transform.position;
        previousPlayerPosition = player.transform.position;

        //For camera zoom in
        playerHeightThreshold = player.transform.position.y;
    }

    void LateUpdate()
    {

        //CheckPlayerTrigger();

        //if(isColliding && player.transform.position.x > previousPlayerPosition.x)
        //{
        //    previousPlayerPosition = player.transform.position;

        //    //transform.position = new Vector3((cameraPosition.position.x + player.transform.position.x), cameraPosition.position.y, 0.0f);
        //    MoveCameraPosition();
        //    //MoveTriggerPosition();
        //}
        //else if (isColliding)
        //{
        //    MoveCameraPosition();
        //}
        //else
        //{
        //    //We need this to set our position when we are outside of the trigger box
        //    //previousPlayerPosition = player.transform.position;
        //    Debug.Log("Camera not moving");
        //}

        if(player.transform.position.y < playerHeightThreshold)
        {
            MoveCameraPosition();
            CameraZoomIn();
        }
        else
        {
            MoveCameraPosition();
        }
    }

    void MoveCameraPosition()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, cameraPosition.position.y, cameraPosition.position.z);
    }

    void CameraZoomIn()
    {
        transform.position = Vector3.Lerp(transform.position, cameraZoomPosition.position, Time.deltaTime * zoomSpeed);
    }

    //void MoveTriggerPosition()
    //{
    //    trigger.transform.position = new Vector3(trigger.transform.position.x + 1.0f, trigger.transform.position.y, trigger.transform.position.z);
    //}

    //void CheckPlayerTrigger()
    //{
    //    if(playerCollider.bounds.Intersects(triggerCollider.bounds))
    //    {
    //        isColliding = true;
    //    }
    //    else
    //    {
    //        isColliding = false;
    //    }
    //}
}
