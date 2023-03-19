using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlockRandomColour : MonoBehaviour
{
    public float brightness;
    [SerializeField] private float saturation;
    public TextMeshProUGUI healthText;
    [SerializeField] private float healthTextBrightness = 0.3f;
        
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
        Color.RGBToHSV(color,out var h, out var s, out var v);
        healthText.color = Color.HSVToRGB(h, s, healthTextBrightness);
    }
}