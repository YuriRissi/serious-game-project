using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class GameManeger : MonoBehaviour
{
    public static Vector3 mouseWP;
    public TextMeshProUGUI scoreText;
    public static int totalScore;
    public static int levelScore;
    public static int gameLevel;
    public static string levelDescription;
    public static float performance;
    public static System.DateTime timeStartLevel;


    //Level modelation
    private int totalSpawn;
    private List<GameObject> enemiesToSpawn;
    private bool isUnilateral;
    private int simultaneousAllowed;

    private int less40;
    private int btw40n50;
    private int btw50n60;
    private int btw60n80;
    private int more80;

    //Aux
    private int countSpawn;
    private int countFirework;
    private int countIncrementModularization;
    private bool isSpawnCourotineOn;
    private bool isFireworkCourotineOn;
    private bool isFinalLevel;
    private bool isEndLevelCalled;
    private int enemyDamage;
    private int winStreak;
    private int loseStreak;
    private int repeatLevel;
    private int levelMultiplier;
    private float scoreMultiplier;
    private float winStreakMult;
    private float modulHealthMult;
    private float modulSpeedMult;
    private float camPosition;


    private GameObject[] instantiatedEnemies;
    private int toggle;

    //GameObjects
    public List<GameObject> enemyA;
    public List<GameObject> enemyB;
    public List<GameObject> enemyC;
    public List<GameObject> enemyD;

    public GameObject MainMenu;
    public GameObject GameOverMenu;
    public GameObject FinalMenu;
    public GameObject LevelTrasintionCanvas;
    public GameObject ScoreCanvas;
    public GameObject LifeMenu;
    public GameObject VCam;

    public GameObject LureGameObject;
    public List<GameObject> fillLure;
    public GameObject Particles;
    public GameObject Firework;

    public AudioSource fireWorksSoundEffect;

    private static GameManeger instance;
    private Coroutine spwanCoroutine;
    public static GameManeger Instance => instance;
    void Awake()
    {

        instance = this;

        gameLevel++;
        instantiatedEnemies = new GameObject[0];
        enemiesToSpawn = new List<GameObject>();

        Enemy.modularizedHealth = 1f;
        Enemy.modularizedSpeed = 0.8f;
        Enemy.minDist = 3f;


        scoreText.text = "0";
        toggle = 1;

        Cursor.visible = false;
    }

    private void OnEnable()
    {
        countSpawn = 0;
        countFirework = 0;
        levelMultiplier = 0;
        levelScore = 0;
        isUnilateral = false;
        isFinalLevel = false;
        isEndLevelCalled = false;
        enemiesToSpawn.Clear();


        switch (gameLevel)
        {
            case 1:

                levelDescription = "Fase 1";

                BuildEnimiesToSpwanList(0, 0, 0, 1);
                isUnilateral = true;
                simultaneousAllowed = 2;
                totalSpawn = 6;

                less40 = 1;
                btw40n50 = btw50n60 = btw60n80 = more80 = 2;

                break;

            case 2:

                levelDescription = "Fase 2 tipo X";

                BuildEnimiesToSpwanList(0, 0, 0, 1);
                simultaneousAllowed = 1;
                totalSpawn = 6;

                less40 = btw40n50 = btw50n60 = btw60n80 = more80 = 1;

                repeatLevel++;

                break;

            case 3:

                levelDescription = "Fase 2 tipo Y";

                BuildEnimiesToSpwanList(1, 0, 0, 1);
                simultaneousAllowed = 2;
                totalSpawn = 8;

                less40 = btw40n50 = btw50n60 = 0;
                btw60n80 = more80 = 1;
                levelMultiplier = 2 - repeatLevel;

                break;

            case 4:

                levelDescription = "Fase 3 - Primeira repetição";

                BuildEnimiesToSpwanList(1, 0, 0, 0);
                simultaneousAllowed = 2;
                totalSpawn = 10;

                less40 = btw40n50 = btw50n60 = btw60n80 = more80 = 1;
                
                break;

            case 5:

                levelDescription = "Fase 3 - Segunda repetição";

                BuildEnimiesToSpwanList(1, 0, 0, 0);
                simultaneousAllowed = 2;
                totalSpawn = 10;

                less40 = btw40n50 = btw50n60 = btw60n80 = more80 = 1;

                break;

            case 6:

                levelDescription = "Fase 4 - Primeira repetição";

                BuildEnimiesToSpwanList(0, 0, 1, 0);
                simultaneousAllowed = 1;
                totalSpawn = 3;

                less40 = btw40n50 = btw50n60 = btw60n80 = more80 = 1;

                break;

            case 7:

                levelDescription = "Fase 4 - Segunda repetição";

                BuildEnimiesToSpwanList(0, 0, 1, 0);
                simultaneousAllowed = 1;
                totalSpawn = 3;

                less40 = btw40n50 = btw50n60 = btw60n80 = more80 = 1;

                break;

            case 8:

                levelDescription = "Fase 5 - Primeira repetição";

                BuildEnimiesToSpwanList(0, 1, 0, 0);
                simultaneousAllowed = 2;
                totalSpawn = 7;

                less40 = btw40n50 = btw50n60 = btw60n80 = more80 = 1;

                break;

            case 9:

                levelDescription = "Fase 5 - Segunda repetição";

                BuildEnimiesToSpwanList(0, 1, 0, 0);
                simultaneousAllowed = 2;
                totalSpawn = 7;

                less40 = btw40n50 = btw50n60 = btw60n80 = more80 = 1;

                break;

            case 10:

                levelDescription = "Fase 6 - Default";

                BuildEnimiesToSpwanList(2, 4, 0, 1);
                simultaneousAllowed = 2;
                totalSpawn = 12;

                less40 =  1;
                btw40n50 = btw50n60 = 0;
                btw60n80 = 3;
                more80 = 4;

                break;
            
            case 11:

                levelDescription = "Fase 6 - Desempenho menor que 40% na última tentativa";

                BuildEnimiesToSpwanList(2, 4, 0, 0);
                simultaneousAllowed = 2;
                totalSpawn = 9;

                less40 = btw40n50 = btw50n60 = 1;
                btw60n80 = more80 = 2;

                repeatLevel =  1;

                break;

            case 12:

                levelDescription = "Fase 6 - Desempenho menor que 60% na última tentativa";

                BuildEnimiesToSpwanList(2, 4, 0, 1);
                simultaneousAllowed = 1;
                totalSpawn = 9;

                less40 = btw40n50 = btw50n60 = 0;
                btw60n80 = more80 = 1;

                break;

            case 13:

                levelDescription = "Fase 7 - Default";

                BuildEnimiesToSpwanList(2, 4, 1, 1);
                simultaneousAllowed = 2;
                totalSpawn = 12;

                less40 = btw40n50 = btw50n60 = 2;
                btw60n80 = more80 = 3;
                levelMultiplier = 3 - repeatLevel;

                repeatLevel = 1;

                break;

            case 14:

                levelDescription = "Fase 7 - Improve";

                BuildEnimiesToSpwanList(2, 4, 1, 1);
                simultaneousAllowed = 3;
                totalSpawn = 12;

                less40 = btw40n50 = btw50n60 = 1;
                btw60n80 = more80 = 2;
                levelMultiplier = 8;

                repeatLevel = 1;

                break;

            case 15:

                levelDescription = "Fase 7 - Desempenho menor que 60% - repetir último nível;";

                BuildEnimiesToSpwanList(2, 4, 1, 1);
                simultaneousAllowed = 9;
                totalSpawn = 5;

                less40 = btw40n50 = btw50n60 = 0;
                btw60n80 = more80 = 1;

                break;

        }

        SetActiveGameInterface(true);
        spwanCoroutine = StartCoroutine(SpawnEnemys());
        isSpawnCourotineOn = true;
        timeStartLevel = System.DateTime.Now;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            VCam.GetComponent<Transform>().position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            VCam.GetComponent<Transform>().position -= new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Particles.GetComponent<Transform>().localScale += new Vector3(0.2f, 0.2f, 0.05f);
            Enemy.minDist += 1.5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Particles.GetComponent<Transform>().localScale -= new Vector3(0.2f, 0.2f, 0.05f);
            Enemy.minDist -= 1.5f;
        }
        camPosition = VCam.GetComponent<Transform>().position.y;
    }

    private void FixedUpdate()
    {
        scoreText.text = totalScore.ToString();
        instantiatedEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(levelDescription);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mouseWP = raycastHit.point;
            Particles.transform.position = new Vector3(mouseWP.x, -5.9f, mouseWP.z);

        }

        if(totalScore >= 50)
        {
            fillLure[0].SetActive(true);
        }

        if (totalScore >= 100)
        {
            fillLure[1].SetActive(true);
        }

        if (countSpawn == totalSpawn && !isSpawnCourotineOn && instantiatedEnemies.Length == 0 && !isEndLevelCalled)
        {
            EndLevel();
            isEndLevelCalled = true;

            if (!isFireworkCourotineOn)
            {        
                StartCoroutine(SpawnFireworks((isFinalLevel ? 60 : 30)));
                //fireWorksSoundEffect.Play();
                isFireworkCourotineOn = true;
            }            
        }

        if (Enemy.modularizedHealth < 0.4f) Enemy.modularizedHealth = 0.4f;
        if (Enemy.modularizedSpeed < 0.5f) Enemy.modularizedSpeed = 0.6f;
    }

    private void BuildEnimiesToSpwanList(int occurrenceA, int occurrenceB, int occurrenceC, int occurrenceD)
    {
        for (int i = 0; i < occurrenceA; i++)
        {
            enemiesToSpawn.AddRange(enemyA);
        }
        for (int i = 0; i < occurrenceB; i++)
        {
            enemiesToSpawn.AddRange(enemyB);
        }
        for (int i = 0; i < occurrenceC; i++)
        {
            enemiesToSpawn.AddRange(enemyC);
        }
        for (int i = 0; i < occurrenceD; i++)
        {
            enemiesToSpawn.AddRange(enemyD);
        }
    }
    private IEnumerator SpawnEnemys()
    {

        Vector3 unitCircle = Random.insideUnitCircle.normalized;
        var spawnCircle = unitCircle * 21f;
        Vector3 spawnPosition;

        if (isUnilateral)
        {
            var rangeX = Random.Range(-6f, 6f);
            var rangeY = Random.Range(16.5f, 21f);
            spawnPosition = new Vector3(rangeX, 0.25f, toggle * rangeY);
        }
        else 
        {
            spawnPosition = new Vector3(spawnCircle.x, 0.25f, spawnCircle.y); 
        }
        
        
        int index = Random.Range(0, enemiesToSpawn.Count);

        if (countSpawn == totalSpawn)
        {
            isSpawnCourotineOn = false;
            yield break;
        }
        if (instantiatedEnemies.Length < simultaneousAllowed)
        {
            Instantiate(enemiesToSpawn[index], spawnPosition, Quaternion.identity);
            countSpawn++;
            toggle *= -1;
        }

        yield return new WaitForSeconds(2f);
        yield return SpawnEnemys();

    }

    private void EndLevel()
    {
        var levelIncrement = ModularizeRemainingLife(less40, btw40n50, btw50n60, btw60n80, more80);

        if (levelIncrement == 0)
        {
            repeatLevel++;
        }
        else
        {
            winStreak++;
        }
        loseStreak = 0;

        if (gameLevel == 1 && levelIncrement == 1 )
        {
            winStreak--;
            GenerateTextData();
        }
        else if (gameLevel == 3 && repeatLevel >= 3)
        {
            GenerateTextData();
            Enemy.modularizedHealth -= 0.2f;
            Enemy.modularizedSpeed -= 0.1f;
            if (Enemy.modularizedHealth == 0.4f) gameLevel++;
            repeatLevel = 2;
        }
        else if(gameLevel == 14 && levelIncrement == 2)
        {
            totalScore = (totalScore - levelScore) + levelScore * 5;
            levelScore *= 5;
            GenerateTextData();
        }
        else if ((gameLevel + levelIncrement) > 15 || repeatLevel >= 3)
        {
            isFinalLevel = true;
            GenerateTextData();
        }
        else GenerateTextData();

        gameLevel += levelIncrement;

        if (performance >= 70) countIncrementModularization++;
        else countIncrementModularization = 0;

        if (countIncrementModularization == 2) Enemy.modularizedHealth += 0.2f;
        if (countIncrementModularization == 3) Enemy.modularizedSpeed += 0.2f;
    }

    public void GameOver()
    {
        StopCoroutine(spwanCoroutine);

        performance = 0;
        foreach (GameObject enemy in instantiatedEnemies)
        {
            GameObject.Destroy(enemy);
        }

        loseStreak++;
        repeatLevel++;
        if (loseStreak == 1) Enemy.modularizedHealth -= 0.1f;
        if (loseStreak == 2) Enemy.modularizedSpeed -= 0.1f;
        winStreak = 0;
        if (loseStreak >= 3)
        {
            GameOverMenu.SetActive(true);
            SetActiveGameInterface(false);
            gameObject.SetActive(false);
        }
        else
        {
            LevelTrasintion.nextLevel = false;
            LevelTrasintionCanvas.SetActive(true);
            SetActiveGameInterface(false);
            gameObject.SetActive(false);
        }
        GenerateTextData();

    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private IEnumerator SpawnFireworks(int total)
    {
        Vector3 ran = Random.insideUnitCircle.normalized;
        ran *= Random.Range(0f, 10f);
        var spawnPosition = new Vector3(ran.x, camPosition - 5f, ran.y);

        Instantiate(Firework, spawnPosition, Quaternion.identity);
        countFirework++;
        yield return new WaitForSeconds(0.2f);
        
        if (countFirework == total)
        {
            yield return new WaitForSeconds(2f);
            isFireworkCourotineOn = false;

            if (isFinalLevel)
            {
                FinalMenu.SetActive(true);
                SetActiveGameInterface(false);
                gameObject.SetActive(false);
            }
            else
            {
                LevelTrasintion.nextLevel = true;
                LevelTrasintionCanvas.SetActive(true);
                SetActiveGameInterface(false);
                gameObject.SetActive(false);
            }

            yield break;
        }
        yield return SpawnFireworks(total);

    }
    public void ListSetActive(List<GameObject> list, bool boolean)
    {
        foreach (GameObject gameobject in list)
        {
            gameobject.SetActive(boolean);
        }
    }

    public void RestartParameters()
    {
        gameLevel = 1;
        totalScore = 0;
        loseStreak = 0;
        winStreak = 0;
        repeatLevel = 0;
        countIncrementModularization = 0;
        Enemy.modularizedHealth = 1f;
        Enemy.modularizedSpeed = 1f;
    }

    private void SetActiveGameInterface(bool boolean)
    {
        LureGameObject.SetActive(boolean);
        if(!boolean) ListSetActive(fillLure, boolean);
        Particles.SetActive(boolean);
        LifeMenu.SetActive(boolean);
        ScoreCanvas.SetActive(boolean);
    }

    public IEnumerator FinalFireworks()
    {
        Vector3 ran = Random.insideUnitCircle.normalized;
        ran *= 3f;
        var spawnPosition = new Vector3(ran.x, camPosition - 5f, ran.y);

        Instantiate(Firework, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(2f);

        yield return FinalFireworks();

    }

    public void GenerateTextData()
    {
        //Path of the file
        string path = Application.dataPath + "/data-collect.txt";
        //Create File if it doesn't exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
        //Content of the file
        string content = "";
        if (gameLevel == 2) content = "\n\n-----------------Nova sessão-----------------n\n";
         content += "\n\n" + levelDescription + "- " + (performance == 0f ? "DERROTA" : "SUCESSO") + "\n\n";
         content += "isFinalLevel: " + isFinalLevel + "\n";
         content += "Pontuação no nível: " + levelScore + "\n";
         content += "Pontuação total: " + totalScore + "\n";
         content += "N.Inimigos: " + totalSpawn + "\n";
         content += "N.Inimigos simultâneos: " + simultaneousAllowed + "\n";
        content += "Sequência de vitórias: " + winStreak + "\n";
         content += "Sequência de derrotas: " + loseStreak + "\n";
         content += "N. Repetição de nível: " + repeatLevel + "\n";
         content += "Vidas restantes: " + performance + "%" + "\n";
         content += "Modularização de vida: " + Enemy.modularizedHealth + "\n";
         content += "Modularização de velocidade: " + Enemy.modularizedSpeed + "\n";
         content += "Tempo total: " + (System.DateTime.Now - timeStartLevel).Minutes + "min " + (System.DateTime.Now - timeStartLevel).Seconds + "sec \n\n";
         content += "Multiplicador do nível: " + levelMultiplier + "x" + "\n";
         content += "Multiplicador winStreak: " + winStreakMult + "x" + "\n";
         content += "Multiplicador de modularização da vida: " + modulHealthMult + "x" + "\n";
         content += "Multiplicador de modularização da velocidade: " + modulSpeedMult + "x" + "\n";
         content += "Multiplicador total: " + scoreMultiplier + "x" + "\n\n";
         content += "Distância de reconhecimento: " + Enemy.minDist + " (default = 3f)" + "\n";
         content += "Altura da camêra: " + VCam.GetComponent<Transform>().position.y + "(default = 30)" + "\n\n";
         content += "\nLog Date: " + System.DateTime.Now + "\n";

        //Add some text to it
        File.AppendAllText(path, content);
    }
    private int ModularizeRemainingLife(int less40, int btw40n50, int btw50n60, int btw60n80, int more80)
    {
        var percentage = Lure.percentageLifeRemaining;
        performance = percentage * 100;
        if (percentage <= 0.4f) return less40;
        else if (percentage > 0.4f && percentage < 0.5f) return btw40n50;
        else if (percentage >= 0.5f && percentage < 0.6f) return btw50n60;
        else if (percentage >= 0.6f && percentage < 0.8f) return btw60n80;
        else if (percentage >= 0.8f) return more80;
        else return 0;
    }

    public void IncrementScore(int score)
    {
        winStreakMult = ((float)winStreak / 10) * 2;
        modulHealthMult = (Enemy.modularizedHealth - 1) * 2;
        modulSpeedMult = (Enemy.modularizedSpeed - 1) * 2;
        scoreMultiplier = 1 + levelMultiplier + winStreakMult + modulHealthMult + modulSpeedMult;
        if (scoreMultiplier < 0.5f) scoreMultiplier = 0.5f;
        var calculateScore = Mathf.RoundToInt(score * scoreMultiplier);
        levelScore += calculateScore;
        totalScore += calculateScore;
    }

    public void SetEnemyDamage(int damage)
    {
        
        enemyDamage = damage;
        
    }

    public int GetEnemyDamage()
    {

        return enemyDamage;

    }

}

