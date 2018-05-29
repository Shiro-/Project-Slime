using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    
    private Rigidbody rb;
    private float freezeAxis = 0.0f;

    private GameObject[] ground;

    private GameObject gPrev;
    private GameObject gCurrent;
    private GameObject gNext;

    private int pGround;
    private Transform groundT;

    private float groundL = 20.0f;
    private float gOffset = 10.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        ground = GameObject.FindGameObjectsWithTag("Ground");
        gCurrent = ground[0];
        gNext = ground[1];
        gPrev = ground[2];
        pGround = 0;

        gPrev.GetComponent<Transform>().SetPositionAndRotation(new Vector3(-2 * groundL, 0.0f, 0.0f), Quaternion.identity);
        gCurrent.GetComponent<Transform>().SetPositionAndRotation(new Vector3(0 * groundL, 0.0f, 0.0f), Quaternion.identity);
        gNext.GetComponent<Transform>().SetPositionAndRotation(new Vector3(1 * groundL, 0.0f, 0.0f), Quaternion.identity);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            //groundT = other.GetComponentInParent<Transform>();
            pGround = Mathf.FloorToInt((rb.position.x + gOffset) / groundL);
            gCurrent = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            pGround = Mathf.FloorToInt((rb.position.x + gOffset) / groundL);
            //Set previous to one we just exited

            //if (pGround < 1)
           // {
                //gNext = ground[2];
                //gPrev = ground[0];
           // }
            //else
            //{
                gNext = gPrev.gameObject;
                gPrev = other.gameObject;

                groundT = gNext.GetComponent<Transform>();
                gNext.GetComponent<Transform>().SetPositionAndRotation(new Vector3((pGround + 1) * groundL, 0.0f, 0.0f), Quaternion.identity);
            //}  
        }
    }
}
