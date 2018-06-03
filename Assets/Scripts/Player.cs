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

        #region Ground Stuff

        ground = GameObject.FindGameObjectsWithTag("Ground");
        gCurrent = ground[0];
        gNext = ground[1];
        gPrev = ground[2];

        //Initialize the ground chunks' positions so we're moving the right ones
        gPrev.GetComponent<Transform>().SetPositionAndRotation(new Vector3(2 * groundL, 0.0f, 0.0f), Quaternion.identity);
        gCurrent.GetComponent<Transform>().SetPositionAndRotation(new Vector3(0 * groundL, 0.0f, 0.0f), Quaternion.identity);
        gNext.GetComponent<Transform>().SetPositionAndRotation(new Vector3(1 * groundL, 0.0f, 0.0f), Quaternion.identity);

        pGround = 0;

        #endregion
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 mover = new Vector3(moveX * _speed * Time.deltaTime, 0.0f, moveZ * _speed * Time.deltaTime);
        
        mover.y = Mathf.Clamp(0.0f, -10.0f, 1.0f);
        rb.velocity = mover;
        //rb.MovePosition(transform.position + mover);
        //rb.AddForce(mover);
    }

    private void OnTriggerEnter(Collider other)
    {
        //We just use this to set current for now (may not be necessary?)
        if (other.tag == "Ground")
        {
            //groundT = other.GetComponentInParent<Transform>();
            //pGround = Mathf.FloorToInt((rb.position.x + gOffset) / groundL);
            gCurrent = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            float oldGround = pGround;

            //Player's current ground "tile"
            pGround = Mathf.FloorToInt((rb.position.x + gOffset) / groundL);

            //This check ensures that we never put any ground before the first section
            if (pGround > 0)
            {
                //Moving forward
                if (oldGround < pGround)
                {
                    gNext = gPrev.gameObject;
                    gPrev = other.gameObject;

                    groundT = gNext.GetComponent<Transform>();
                    gNext.GetComponent<Transform>().SetPositionAndRotation(new Vector3((pGround + 1) * groundL, 0.0f, 0.0f), Quaternion.identity);
                }
                //Moving backward
                else if (oldGround > pGround)
                {
                    gPrev = gNext.gameObject;
                    gNext = other.gameObject;

                    groundT = gNext.GetComponent<Transform>();
                    gPrev.GetComponent<Transform>().SetPositionAndRotation(new Vector3((pGround - 1) * groundL, 0.0f, 0.0f), Quaternion.identity);
                }
            }
        }
    }
}
