using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public Material fireworkMaterial;
    private readonly UnityEngine.Color[] colors = { Color.blue, Color.red, Color.green, Color.cyan, Color.magenta, Color.yellow, Color.white };
    private int index;
    void Start()
    {
        index = Random.Range(0, colors.Length);
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", (colors[index] * 5.0f));
    }

}
