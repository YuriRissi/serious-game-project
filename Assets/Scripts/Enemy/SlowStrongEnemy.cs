using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowStrongEnemy : Enemy
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        points = 5;
        maxHealth = 150;
        damage = 4;
        LifeModularizer();
    }
    void FixedUpdate()
    {
        Vector3 dir = MoveDirection();
        MoveSpeed(rb, dir, 0.75f);
        DistanceMonitoring(1f);
    }
}
