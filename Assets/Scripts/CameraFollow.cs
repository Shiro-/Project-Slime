using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject trigger;
    public Transform cameraPosition;

    Collider playerCollider;
    Collider triggerCollider;

    bool isColliding;

    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        triggerCollider = trigger.GetComponent<Collider>();
    }

    void FixedUpdate()
    {

        CheckPlayerTrigger();

        if(isColliding)
        {
            transform.position = new Vector3((cameraPosition.position.x + player.transform.position.x), cameraPosition.position.y, 0.0f);
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
