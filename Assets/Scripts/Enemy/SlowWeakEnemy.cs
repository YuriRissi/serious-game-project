using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowWeakEnemy : Enemy
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        points = 2;
        maxHealth = 50;
        damage = 2;
        LifeModularizer();
    }
    void FixedUpdate()
    {
        Vector3 dir = MoveDirection();
        MoveSpeed(rb, dir, 1.1f);
        DistanceMonitoring(0.7f);
    }
}
