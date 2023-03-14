using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float MaxVelocity;
    public static float minDist;
    public float slow = 1f;
    public float distanceEye;
    public bool isCoroutineStarted = false;

    public GameObject DropCoin;

    public Vector3 MoveDirection()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Lure").transform.position);
        var heading = GameObject.FindGameObjectWithTag("Lure").transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Vector3 dir = direction;
        return dir;
    }
    public void DistanceMonitoring(float dist)
    {
        distanceEye = Vector3.Distance(GameManeger.mouseWP, transform.position);
        if (distanceEye < dist && !isCoroutineStarted)
        {
            StartCoroutine(KillEnemys());
            isCoroutineStarted = true;

        }
        else if (distanceEye > dist && isCoroutineStarted)
        {
            slow = 1f;
            StopAllCoroutines();
            isCoroutineStarted = false;
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lure"))
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator KillEnemys()
    {
        slow = 0.1f;
        yield return new WaitForSeconds(1.5f);

        DestroyEnemy();
        GameManeger.Score++;

        yield break;
    }
    public void DestroyEnemy()
    {
        Vector3 position = transform.position;
        Instantiate(DropCoin, new Vector3(position.x, 1f, position.z), Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
    }
}
