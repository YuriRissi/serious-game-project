using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{
    public float MaxVelocity =1.5f;
    public float minDist = 2;
    public int maxHealth = 200;
    public int currentHealth;

    private Rigidbody rb;
    private float distanceEye;
    
    public GameObject DropCoin;
    public HealthBar healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void FixedUpdate()
    {

        transform.LookAt(GameObject.FindGameObjectWithTag("Lure").transform.position);
        var heading = GameObject.FindGameObjectWithTag("Lure").transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Vector3 dir = direction;

        rb.velocity = dir * MaxVelocity;


        distanceEye = Vector3.Distance(GameManeger.mouseWP, transform.position);
        if (distanceEye < minDist)
        {
            TakeDamage(1);   
        }
        if (currentHealth == 0)
        {
            DestroyEnemy();
        }
        
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lure"))
        {
            Destroy(gameObject);  
        }
    }
    public void DestroyEnemy()
    {
        Vector3 position = transform.position;
        Instantiate(DropCoin, new Vector3(position.x, 1f, position.z) , Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}



