using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaces : MonoBehaviour
{
    public CanvasScaler Menu;

    public GameObject lifeInterface;
    public GameObject scoreInterface;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Menu.scaleFactor += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Menu.scaleFactor -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lifeInterface.GetComponent<RectTransform>().localPosition += new Vector3(0, 10, 0);
            scoreInterface.GetComponent<RectTransform>().localPosition -= new Vector3(0, 10, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lifeInterface.GetComponent<RectTransform>().localPosition -= new Vector3(0, 10, 0);
            scoreInterface.GetComponent<RectTransform>().localPosition += new Vector3(0, 10, 0);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            lifeInterface.GetComponent<RectTransform>().localScale += new Vector3(0.05f, 0.05f, 0.05f);
            scoreInterface.GetComponent<RectTransform>().localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            lifeInterface.GetComponent<RectTransform>().localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            scoreInterface.GetComponent<RectTransform>().localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
