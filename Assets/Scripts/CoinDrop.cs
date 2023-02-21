using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{

    private Rigidbody rb;
    void Awake()
    {
        transform.LeanMoveY(5f, 0.5f);
        transform.LeanRotateY(1200f, 1.5f);
        StartCoroutine(DestroyCoin());

    }


    void FixedUpdate()
    {
        transform.Rotate(0, 5, 0, Space.World);
        
    }

    public IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(6f);

        transform.LeanMove(new Vector3(0, 0.5f, 0), 0.5f);
        transform.LeanScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);

        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);


        yield break;


    }
}
