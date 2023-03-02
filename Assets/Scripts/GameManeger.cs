using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManeger : MonoBehaviour
{
    public static Vector3 mouseWP;
    public TextMeshProUGUI scoreText;
    public static int Score = 0;
    public static int gameLevel;

    //Level modelation
    private float SpawnCd;
    private int totalBossSpawn;
    private int levelSpawn;
    private int totalSpawn;
    
   //Aux
    private int countSpawn;
    private int hiddenScore;
    private bool isCourotineOn;


    public List<GameObject> enemysToSpawn;
    public List<GameObject> boss;

    public GameObject GameOverMenu;
    public GameObject MainMenu;
    public GameObject LevelTrasintion;

    public GameObject Lure;
    public GameObject LureE;
    public GameObject LureEE;
    public GameObject Particles;


    private static GameManeger instance;
    private Coroutine enemysCoroutine;
    public static GameManeger Instance => instance;
    void Awake()
    {

        instance = this;

    }

    private void OnEnable()
    {
        scoreText.text = "0";
        Score = 0;
        countSpawn = 0;

        gameLevel++;
        switch (gameLevel)
        {
            case 1:

                Enemy.MaxVelocity = 3f;
                Enemy.minDist = 2.5f;
                SpawnCd = 4f;
                levelSpawn = 1;
                totalSpawn = 2;

                totalBossSpawn = 0;          
                
                break;

            case 2:

                Enemy.MaxVelocity = 3.5f;
                Enemy.minDist = 2.5f;
                SpawnCd = 3.5f;
                levelSpawn = 2;
                totalSpawn = 15;

                totalBossSpawn = 0;

                break;

            case 3:

                Enemy.MaxVelocity = 4f;
                Enemy.minDist = 2f;
                SpawnCd = 3f;
                levelSpawn = 3;
                totalSpawn = 20;

                totalBossSpawn = 0;

                break;

            case 4:

                Enemy.MaxVelocity = 4f;
                Enemy.minDist = 2f;
                SpawnCd = 3f;
                levelSpawn = 4;
                totalSpawn = 30;

                totalBossSpawn = 1;
                Boss.maxHealth = 200;

                break;

            default:

                Enemy.MaxVelocity = 2f;
                Enemy.minDist = 3f;
                SpawnCd = 4.5f;
                levelSpawn = 1;
                totalSpawn = 15;
                totalBossSpawn = 0;

                break;
        }

        Lure.SetActive(true);
        Particles.SetActive(true);
        enemysCoroutine = StartCoroutine(SpawnEnemys());
        isCourotineOn = true;
    }


    private void FixedUpdate()
    {
        hiddenScore += (Score - hiddenScore);
        scoreText.text = Score.ToString();
        Debug.Log(hiddenScore);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mouseWP = raycastHit.point;
            Particles.transform.position = new Vector3(mouseWP.x, -5.9f, mouseWP.z);

        }

        if(hiddenScore >= 30)
        {
            LureE.SetActive(true);
        }

        if (hiddenScore >= 60)
        {
            LureEE.SetActive(true);
        }

        if (countSpawn == totalSpawn && !isCourotineOn)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                gameObject.SetActive(false);
                LevelTrasintion.SetActive(true);
               
            }
        }

    }


    private IEnumerator SpawnEnemys()
    {
        Vector3 ran = Random.insideUnitCircle.normalized;
        ran *= Random.Range(15f, 19.5f);
        var spawnPosition = new Vector3(ran.x, 0.25f, ran.y);

        Vector3 dir = new Vector3(0, 0.25f, 0) - spawnPosition;

        int nEnemy = Random.Range(0, levelSpawn);
        Quaternion newRotation = Quaternion.LookRotation(dir);

        if (countSpawn == totalSpawn && totalBossSpawn != 0)
        {
            Instantiate(boss[totalBossSpawn - 1], spawnPosition, newRotation);
            isCourotineOn = false;
            yield break;
        }
        else if(countSpawn == totalSpawn && totalBossSpawn == 0)
        {
            isCourotineOn = false;
            yield break;
        }
        Instantiate(enemysToSpawn[nEnemy], spawnPosition, newRotation);
        countSpawn++;

        


        yield return new WaitForSeconds(SpawnCd);

        yield return SpawnEnemys();
    }

    public void GameOver()
    {
        StopCoroutine(enemysCoroutine);
        gameObject.SetActive(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        GameObject.Destroy(enemy);
        GameOverMenu.SetActive(true);
        Lure.SetActive(false);
        LureE.SetActive(false);
        LureEE.SetActive(false);
        Particles.SetActive(false);

        gameLevel--;

    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }

}

