using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerAppearance : MonoBehaviour
{

    public Color startColor;
    public SpriteRenderer spriteRenderer;
    public Light2D light2D;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.color = startColor;
        light2D.color = startColor;
    }

    public void ChangeColor(Color color, float duration)
    {
        StartCoroutine(ChangeColorCoroutine(color, duration));
    }

    private IEnumerator ChangeColorCoroutine(Color color, float duration)
    {
        spriteRenderer.color = color;
        light2D.color = color;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = startColor;
        light2D.color = startColor;
    }
}
