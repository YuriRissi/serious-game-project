using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelTrasintion : MonoBehaviour
{
    public List <GameObject> betweenLevels;
    public List <GameObject> lostLevel;

    public GameObject BGNextLevel;
    public GameObject BGTryAgain;

    public AudioSource ASWinLevel;
    public AudioSource ASLostLevel;

    public static bool nextLevel;

    private void OnEnable()
    {
        gameObject.GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f);
        if (nextLevel)
        {
            StartCoroutine(TextTransition(betweenLevels));
            ASWinLevel.Play();
            BGNextLevel.SetActive(true);
        }
        else
        {
            StartCoroutine(TextTransition(lostLevel));
            ASLostLevel.Play();
            BGTryAgain.SetActive(true);
        }
    }
    public IEnumerator TextTransition(List<GameObject> imageList)
    {

        yield return new WaitForSeconds(1f);

        foreach (GameObject image in imageList)
        {
            image.GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f);
            image.LeanScale(new Vector3(2.5f, 2.5f), 1.2f);
            yield return new WaitForSeconds(1.7f);
            image.GetComponent<CanvasGroup>().LeanAlpha(0, 0.8f);
            yield return new WaitForSeconds(1.2f);
        }
        foreach (GameObject image in imageList)
        {
            image.LeanScale(new Vector3(1f, 1f), 0);
        }

        gameObject.GetComponent<CanvasGroup>().LeanAlpha(0,0f);
        gameObject.SetActive(false);
        GameManeger.Instance.Enable();

        BGTryAgain.SetActive(false);
        BGNextLevel.SetActive(false);

        yield break;
    }       
}
