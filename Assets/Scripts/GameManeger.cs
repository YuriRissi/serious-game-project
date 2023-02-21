using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManeger : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnCd = 3f;
    public static int Score = 0;


    public static Vector3 mouseWP;
    public TextMeshProUGUI scoreText;

    public List<GameObject> enemysToSpawn;
    public GameObject GameOverMenu;
    public GameObject MainMenu;
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
        Lure.SetActive(true);
        Particles.SetActive(true);
        enemysCoroutine = StartCoroutine(SpawnEnemys());
        scoreText.text = "0";
        Score = 0;
    }


    private void FixedUpdate()
    {

        scoreText.text = Score.ToString();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mouseWP = raycastHit.point;
            Particles.transform.position = new Vector3(mouseWP.x, -5.9f, mouseWP.z);

        }

        if(Score >= 15)
        {
            LureE.SetActive(true);
        }

        if (Score >= 30)
        {
            LureEE.SetActive(true);
        }

    }


    private IEnumerator SpawnEnemys()
    {
        Vector3 ran = Random.insideUnitCircle.normalized;
        ran *= Random.Range(15f, 19.5f);
        var spawnPosition = new Vector3(ran.x, 0.25f, ran.y);

        Vector3 dir = new Vector3(0, 0.25f, 0) - spawnPosition;

        int nEnemy = Random.Range(0, enemysToSpawn.Count);
        Quaternion newRotation = Quaternion.LookRotation(dir);

        if (nEnemy == 3)
        {
            newRotation *= Quaternion.Euler(0, 90, 0);
        }

        Instantiate(enemysToSpawn[nEnemy], spawnPosition, newRotation);
                                            
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

    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }

}

