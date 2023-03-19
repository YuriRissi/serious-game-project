using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float modularizedSpeed;
    public static float modularizedHealth;
    public static float minDist;
    
    public int maxHealth;
    public int currentHealth;
    public int points;
    public int damage;
    
    private float slow;
    private float distanceEye;

    public GameObject DropCoin;
    public HealthBar healthBar;

    public void LifeModularizer()
    {
        maxHealth = (int)Mathf.Round(maxHealth * modularizedHealth);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void MoveSpeed(Rigidbody body, Vector3 direction, float MaxSpeed)
    {
        body.velocity = MaxSpeed * modularizedSpeed * slow * direction;
    }
    public Vector3 MoveDirection()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Lure").transform.position);
        var heading = GameObject.FindGameObjectWithTag("Lure").transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Vector3 dir = direction;
        return dir;
    }
    public void DistanceMonitoring(float inputSlow)
    {
        distanceEye = Vector3.Distance(GameManeger.mouseWP, transform.position);
        if (distanceEye < minDist) 
        {
            TakeDamage(1);
            slow = inputSlow;
        }
        else if (distanceEye > minDist)
        {
            slow = 1f;
        }
        if (currentHealth == 0)
        {
            DestroyEnemy();
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lure"))
        {
            Destroy(gameObject);
            GameManeger.Instance.SetEnemyDamage(damage);
        }
    }
    public void DestroyEnemy()
    {
        Vector3 position = transform.position;
        Instantiate(DropCoin, new Vector3(position.x, 1f, position.z), Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
        GameManeger.Instance.IncrementScore(points);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
