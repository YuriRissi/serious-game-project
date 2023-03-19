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
        play.gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.5f).setLoopPingPong();
        title.gameObject.LeanScale(new Vector3(1f, 1f), 0.5f).setLoopPingPong();
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

}
