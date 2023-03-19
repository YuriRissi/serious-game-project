using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyRot : MonoBehaviour
{
    //public static float MaxVelocity;
    //public static float minDist;
    //private float Slow = 1f;
    //private Rigidbody rb;
    //private float distanceEye;
    //private bool isCoroutineStarted = false;

    //public GameObject DropCoin;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();

//    }
//    void FixedUpdate()
//    {

//        transform.LookAt(GameObject.FindGameObjectWithTag("Lure").transform.position);
//        var heading = GameObject.FindGameObjectWithTag("Lure").transform.position - transform.position;
//        var distance = heading.magnitude;
//        var direction = heading / distance;
//        Vector3 dir = direction;
//        Vector3 dirRotate = Quaternion.Euler(0, 90, 0) * dir * 2;

//        rb.velocity = (dir * 0.3f + dirRotate) * MaxVelocity * Slow;

//        distanceEye = Vector3.Distance(GameManeger.mouseWP, transform.position);
//        if (distanceEye < minDist && !isCoroutineStarted)
//        {
//            StartCoroutine(KillEnemys());
//            isCoroutineStarted = true;
          
//        }
//        else if (distanceEye > minDist && isCoroutineStarted)
//        {
//            Slow = 1f;
//            StopAllCoroutines();
//            isCoroutineStarted = false;
//        }
        
      
//    }
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Lure"))
//        {
//            Destroy(gameObject);  
//        }
//    }

//    private IEnumerator KillEnemys()
//    {
//        Slow = 0.1f;
//        yield return new WaitForSeconds(1.5f);

//        DestroyEnemy();
//        GameManeger.Score++;

//        yield break;     
//    }
//    private void DestroyEnemy()
//    {
//        Vector3 position = transform.position;
//        Instantiate(DropCoin, new Vector3(position.x, 1f, position.z) , Quaternion.Euler(-90, 0, 0));
//        Destroy(gameObject);
//    }
}

