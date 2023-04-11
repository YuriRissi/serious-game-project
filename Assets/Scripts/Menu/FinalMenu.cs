using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenu : GameOverMenu
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Restart();
        }
    }
    private void OnEnable()
    {
        scoreText.text = GameManeger.totalScore.ToString();
        StartCoroutine(GameManeger.Instance.FinalFireworks());
    }
}
