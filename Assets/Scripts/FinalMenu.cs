using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenu : GameOverMenu
{
    private void OnEnable()
    {
        scoreText.text = GameManeger.totalScore.ToString();
        restart.gameObject.LeanScale(new Vector3(1.05f, 1.05f), 0.3f).setLoopPingPong();
        StartCoroutine(GameManeger.Instance.FinalFireworks());
    }
}
