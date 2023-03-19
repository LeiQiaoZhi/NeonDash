using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlockRandomColour : MonoBehaviour
{
    public float brightness;
    [SerializeField] private float saturation;
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
        var color = ColourHelper.GetRandomColour(brightness, saturation);
        spriteRenderer.color = color;
        light2D.color = color;
    }
}