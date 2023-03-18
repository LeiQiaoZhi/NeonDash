using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlockRandomColour : MonoBehaviour
{
    public float colorIntensity;
    private SpriteRenderer spriteRenderer;
    private Light2D light2D;
    private Color color;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        light2D = GetComponentInChildren<Light2D>();
        SetRandomColour();
    }

    void SetRandomColour()
    {
        var colorVec = new Vector3(Random.value, Random.value, Random.value);
        colorVec = colorVec.normalized * colorIntensity;
        color = new Color(colorVec.x, colorVec.y, colorVec.z);
        spriteRenderer.color = color;
        light2D.color = color;
    }
}