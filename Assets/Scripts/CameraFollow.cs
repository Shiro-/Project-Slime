using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject trigger;
    public Transform cameraPosition;

    private Collider playerCollider;
    private Collider triggerCollider;

    private Vector3 offset;

    private bool isColliding;

    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        triggerCollider = trigger.GetComponent<Collider>();

        //Used so we can move the camera along the x axis only
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {

        CheckPlayerTrigger();

        if(isColliding)
        {
            //transform.position = new Vector3((cameraPosition.position.x + player.transform.position.x), cameraPosition.position.y, 0.0f);
            transform.position = new Vector3(player.transform.position.x + offset.x, cameraPosition.position.y, 0.0f);
        }
        else
        {
            Debug.Log("Camera not moving");
        }
    }

    void CheckPlayerTrigger()
    {
        if(playerCollider.bounds.Intersects(triggerCollider.bounds))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }
}
