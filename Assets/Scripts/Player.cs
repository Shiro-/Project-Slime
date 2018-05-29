using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    
    private Rigidbody rb;
    private float freezeAxis = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 mover = new Vector3(moveX, 1.0f, moveZ) * _speed;

        mover.y = rb.velocity.y;
        rb.velocity = mover;
        

        //rb.freezeRotation = true;
        //rb.constraints = RigidbodyConstraints.FreezeRotationX;
        //rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = Quaternion.Euler(freezeAxis, transform.rotation.y, freezeAxis);

    }

}
