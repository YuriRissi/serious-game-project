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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(StartGame());
        }
    }
    public void Play()
    {
        StartCoroutine(StartGame());
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

        GetComponent<CanvasGroup>().LeanAlpha(0, 0.2f);
        gameManeger.Enable();
        Destroy(gameObject);

        yield break;
    }

}
