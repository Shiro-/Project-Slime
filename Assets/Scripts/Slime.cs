using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float _speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.right * _speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * _speed;
    }

}
