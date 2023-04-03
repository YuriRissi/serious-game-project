using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restart;
    private void OnEnable()
    {
        scoreText.text = GameManeger.totalScore.ToString();
        restart.gameObject.LeanScale(new Vector3(1.05f, 1.05f), 0.3f).setLoopPingPong();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Restart();
        }
    }
    public void Restart()
    {
        GameManeger.Instance.RestartParameters();
        gameObject.SetActive(false);
        GameManeger.Instance.Enable();
        StopAllCoroutines();
    }

   public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
