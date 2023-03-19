using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class LevelTrasintion : MonoBehaviour
{
    public List <TextMeshProUGUI> betweenLevels;
    public List <TextMeshProUGUI> lostLevel;

    public static bool nextLevel;

    private void OnEnable()
    {
        if (nextLevel)
        {
            StartCoroutine(TextTransition(betweenLevels));
        }
        else
        {
            StartCoroutine(TextTransition(lostLevel));
        }
    }
    public IEnumerator TextTransition(List<TextMeshProUGUI> textList)
    {

        yield return new WaitForSeconds(1f);

        foreach (TextMeshProUGUI text in textList)
        {
            text.GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f);
            text.gameObject.LeanScale(new Vector3(2.5f, 2.5f), 1.2f);
            yield return new WaitForSeconds(1.7f);
            text.GetComponent<CanvasGroup>().LeanAlpha(0, 0.8f);
            yield return new WaitForSeconds(1.2f);
        }
        foreach (TextMeshProUGUI text in textList)
        {
            text.gameObject.LeanScale(new Vector3(1f, 1f), 0);
        }

        gameObject.SetActive(false);
        GameManeger.Instance.Enable();

        yield break;
    }       
}
