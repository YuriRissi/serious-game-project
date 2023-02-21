using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float MaxVelocity = 5f;
    private float Slow = 1f;
    private Rigidbody rb;
    private float distanceEye;
    private Vector3 mouseDist;
    public float minDist = 2;
    private bool isCoroutineStarted = false;

    public GameObject DropCoin;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
       

        var heading = GameObject.FindGameObjectWithTag("Lure").transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Vector3 dir = direction;

        rb.velocity = dir * MaxVelocity * Slow;

        mouseDist = GameManeger.mouseWP;

        distanceEye = Vector3.Distance(GameManeger.mouseWP, transform.position);
        if (distanceEye < minDist && !isCoroutineStarted)
        {
            StartCoroutine(KillEnemys());
            isCoroutineStarted = true;
          
        }
        else if (distanceEye > minDist && isCoroutineStarted)
        {
            Slow = 1f;
            StopAllCoroutines();
            isCoroutineStarted = false;
        }
        
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lure"))
        {
            Destroy(gameObject);
            
        }
    }

    public IEnumerator KillEnemys()
    {
        Slow = 0.1f;
        yield return new WaitForSeconds(1.5f);


        DestroyEnemy();
        GameManeger.Score++;


        yield break;
        

    }
    public void DestroyEnemy()
    {
        Vector3 position = transform.position;

        Instantiate(DropCoin, new Vector3(position.x, 1f, position.z) , Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
        
    }
}

