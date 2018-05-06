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
        //float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");

        

    }

}
