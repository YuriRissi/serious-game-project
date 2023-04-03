using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediocreEnemy : Enemy
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        type = "B";
        points = 4;
        maxHealth = 80;
        damage = 2;
        LifeModularizer();
    }
    void FixedUpdate()
    {
        Vector3 dir = MoveDirection();
        MoveSpeed(rb, dir, 1.4f);
        DistanceMonitoring(0.3f);
    }
}
