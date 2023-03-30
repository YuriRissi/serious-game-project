using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    public GameManeger gameManeger;
    public TextMeshProUGUI play;
    public TextMeshProUGUI title;
    public RectTransform scoreRectTransform;

    private void Start()
    {
        scoreRectTransform.anchoredPosition = new Vector2(scoreRectTransform.anchoredPosition.x, -14);
        //play.gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.5f).setLoopPingPong();
        //title.gameObject.LeanScale(new Vector3(1f, 1f), 0.5f).setLoopPingPong();
        StartCoroutine(StartGame());
    }
    public void Play()
    {
        GetComponent<CanvasGroup>().LeanAlpha(0, 0.2f).setOnComplete(OnComplete);
       
    }

    private void OnComplete()
    {
        scoreRectTransform.LeanMoveY(-60.4f, 0.75f).setEaseOutBounce();
        gameManeger.Enable();
        Destroy(gameObject);
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        play.text = "5";
        yield return new WaitForSeconds(1f);
        play.text = "4";
        yield return new WaitForSeconds(1f);
        play.text = "3";
        yield return new WaitForSeconds(1f);
        play.text = "2";
        yield return new WaitForSeconds(1f);
        play.text = "1";
        yield return new WaitForSeconds(1f);

        scoreRectTransform.LeanMoveY(-60.4f, 0.75f).setEaseOutBounce();
        gameManeger.Enable();
        Destroy(gameObject);

        yield break;
    }

}
