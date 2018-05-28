using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    
    private Rigidbody rb;
    private float freezeAxis = 0.0f;

    private GameObject[] ground;

    private Transform gPrev;
    private Transform gCurrent;
    private Transform gNext;

    private int pGround;
    private Transform groundT;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        ground = GameObject.FindGameObjectsWithTag("Ground");
        gCurrent = ground[0].GetComponent<Transform>();
        gNext = ground[1].GetComponent<Transform>();
        pGround = 0;
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
        //rb.constraints = RigidbodyConstraints.FreezeRotationX;
        //rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = Quaternion.Euler(freezeAxis, transform.rotation.y, freezeAxis);

    }

    //Move ground two back ahead of current
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GroundT")
        {
            groundT = other.GetComponentInParent<Transform>();
            pGround = Mathf.FloorToInt(rb.position.x / 20);
            gCurrent = other.GetComponentInParent<Transform>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GroundT")
        {
            pGround = Mathf.FloorToInt(rb.position.x / 20);
            //Set previous to one we just exited
            gNext = gPrev;
            gPrev = other.GetComponentInParent<Transform>();

            gNext.SetPositionAndRotation(new Vector3((pGround + 1) * 20, 0.0f, 0.0f), gNext.rotation);
        }
    }
}
