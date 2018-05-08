using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 mover = new Vector3(moveX, rb.velocity.y, moveZ);
        //rb.velocity = (mover * _speed);
        //rb.AddForce(mover * _speed);
        rb.velocity = new Vector3(mover.x * _speed, rb.velocity.y, mover.z * _speed);

        //rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;

    }

}
