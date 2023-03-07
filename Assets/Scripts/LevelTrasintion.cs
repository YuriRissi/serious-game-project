using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class LevelTrasintion : MonoBehaviour
{
    public List <TextMeshProUGUI> textList;

    private void OnEnable()
    {
        StartCoroutine(TextTransition());
 
    }
   public IEnumerator TextTransition()
    {
        textList[0].GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f);
        textList[0].gameObject.LeanScale(new Vector3(2.5f, 2.5f), 1.2f);
        yield return new WaitForSeconds(1.7f);
        textList[0].GetComponent<CanvasGroup>().LeanAlpha(0, 0.8f);
        yield return new WaitForSeconds(1.2f);

        textList[1].GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f);
        textList[1].gameObject.LeanScale(new Vector3(2.5f, 2.5f), 1.2f);
        yield return new WaitForSeconds(1.7f);
        textList[1].GetComponent<CanvasGroup>().LeanAlpha(0, 0.8f);
        yield return new WaitForSeconds(1.2f);

        textList[2].GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f);
        textList[2].gameObject.LeanScale(new Vector3(2.5f, 2.5f), 1.2f);
        yield return new WaitForSeconds(1.7f);
        textList[2].GetComponent<CanvasGroup>().LeanAlpha(0, 0.8f);
        yield return new WaitForSeconds(1.2f);

        textList[0].gameObject.LeanScale(new Vector3(1f, 1f), 0);
        textList[1].gameObject.LeanScale(new Vector3(1f, 1f), 0);
        textList[2].gameObject.LeanScale(new Vector3(1f, 1f), 0);

        gameObject.SetActive(false);
        GameManeger.Instance.Enable();

        yield break;
    }
}
