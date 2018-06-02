using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Transform cameraPosition;

    // Update is called once per frame

    void LateUpdate()
    {
        transform.position = new Vector3(cameraPosition.position.x + player.transform.position.x, cameraPosition.position.y, 0.0f);
    }
}
