using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Enemy : MonoBehaviour
{
    public static float modularizedSpeed;
    public static float modularizedHealth;
    public static float minDist;
    private static string auxLevelD;
    
    public int maxHealth;
    public int currentHealth;
    public int points;
    public int damage;
    public string type;
    
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
        GenerateTextDeath();
        Destroy(gameObject);
        GameManeger.Instance.IncrementScore(points);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public void GenerateTextDeath()
    {
        //Path of the file
        string path = Application.dataPath + "/heat-map.txt";
        //Create File if it doesn't exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
        //Content of the file
        string content = "";
        if (auxLevelD != GameManeger.levelDescription || !LevelTrasintion.nextLevel)
        {
            content = "\n\n-----------------" + GameManeger.levelDescription + "-----------------\n";
            auxLevelD = GameManeger.levelDescription;
        }
        content += gameObject.transform.position + " - " + type + " - " + (System.DateTime.Now - GameManeger.timeStartLevel).TotalSeconds + " sec\n";

        //Add some text to it
        File.AppendAllText(path, content);
    }
}
