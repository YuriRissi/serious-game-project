using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FastEnemy : Enemy
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 dir = MoveDirection();
        rb.velocity = MaxVelocity * slow * dir;
        DistanceMonitoring(minDist);
    }

}

