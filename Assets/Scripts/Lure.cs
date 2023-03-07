using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Lure : MonoBehaviour
{
    private int health = 0;
    private CinemachineImpulseSource cinemachineImpulseSource;
    public List<GameObject> Lifes;
    private int i = 0;

    void Start()
    {
        health = 3;
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        Lifes[0].SetActive(true);
        Lifes[1].SetActive(true);
        Lifes[2].SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cinemachineImpulseSource.GenerateImpulse();
            Lifes[i].SetActive(false);
            health--;
            i++;

            if (health < 1)
               {
                GameManeger.Instance.GameOver();
               }

        }
    }

    private void OnEnable()
    {
        health = 3;
        i = 0;
        Lifes[0].SetActive(true);
        Lifes[1].SetActive(true);
        Lifes[2].SetActive(true);
    }

}
