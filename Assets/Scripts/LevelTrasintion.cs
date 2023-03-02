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
        textList[0].GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f).setLoopOnce();
        //textList[0].gameObject.LeanScale(new Vector3(2.5f, 2.5f), 1.2f).setLoopCount(2);
        //ShowText(textList[0]);
        //ShowText(textList[1]);
        //ShowText(textList[2]);

        //gameObject.SetActive(false);
        //GameManeger.Instance.Enable();
    }

    private void ShowText(TextMeshProUGUI text)
    {
        text.gameObject.LeanScale(new Vector3(2.5f, 2.5f), 1.2f).setLoopOnce();
        text.GetComponent<CanvasGroup>().LeanAlpha(1, 1.2f);
        //text.gameObject.LeanScale(new Vector3(1f, 1f), 1.2f).setDelay(1.2f);
        //text.gameObject.LeanAlpha(0, 0.4f).callOnCompletes();
    }
}
