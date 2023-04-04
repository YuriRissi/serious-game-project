using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FastWeakEnemy : Enemy
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        type = "A";
        points = 3;
        maxHealth = 25;
        damage = 1;
        LifeModularizer();
    }
    void FixedUpdate()
    {
        Vector3 dir = MoveDirection();
        MoveSpeed(rb, dir, 2f);
        DistanceMonitoring(0.1f);
    }

}

