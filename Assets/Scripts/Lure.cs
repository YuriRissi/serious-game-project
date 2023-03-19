using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Lure : MonoBehaviour
{
    private CinemachineImpulseSource cinemachineImpulseSource;
    public List<GameObject> Lifes;
    
    private int health;
    private int j;
    private int damage;
    public static float percentageLifeRemaining;
    void Start()
    {
        ResetGameLife();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damage = GameManeger.Instance.GetEnemyDamage();
            cinemachineImpulseSource.GenerateImpulse();
            for(int i = 1; i <= damage; ++i)
            {
                Lifes[j].SetActive(false);
                health--;
                j++;
            }
            percentageLifeRemaining = (float)health / Lifes.Count;

            if (health < 1)
               {
                GameManeger.Instance.GameOver();
               }

        }
    }

    private void OnEnable()
    {
        ResetGameLife();
    }
    public void ResetGameLife()
    {
        health = Lifes.Count;
        j = 0;
        percentageLifeRemaining = 1f;
        GameManeger.Instance.ListSetActive(Lifes, true);
    }

}
