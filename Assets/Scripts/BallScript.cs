using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Vector3 ballPos; //setting variable for pos ball
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < - 10)
        {
            rb.velocity = Vector3.zero;
            transform.position = ballPos;
        }
    }
}
