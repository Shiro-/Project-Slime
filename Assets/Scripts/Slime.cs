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
        
        Vector3 mover = new Vector3(_speed, 0.0f, 0.0f);
        rb.AddForce(mover);
    }

}
