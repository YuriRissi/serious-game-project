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

    public AudioSource ASTakeHit;
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
            StartCoroutine(ApllyDamage(damage));

            cinemachineImpulseSource.GenerateImpulse();
            ASTakeHit.Play();

            percentageLifeRemaining = (float)health / Lifes.Count;
        }
    }

    public void Update()
    {
        if (health < 1)
        {
            percentageLifeRemaining = 0;
            StopAllCoroutines();
            ASTakeHit.Stop();
            GameManeger.Instance.GameOver();
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
    private IEnumerator ApllyDamage(int damage)
    {
        for (int i = 1; i <= damage; ++i)
        {
            if (j >= Lifes.Count) yield break;
            Lifes[j].SetActive(false);
            health--;
            j++;
        }

        yield break;
    }

}
