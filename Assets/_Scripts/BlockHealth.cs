using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockHealth : Health
{
    public ParticleSystem destoryEffect;
    public TextMeshProUGUI healthText;
    public Canvas scoreTextCanvas;

    private GameManager gameManager;

    private void Start()
    {
        healthText.text = maxHealth.ToString();
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void ChangeHealth(int change, GameObject from)
    {
        base.ChangeHealth(change, from);
        healthText.text = currentHealth.ToString();
    }

    protected override void Die()
    {
        // effect
        var effect = Instantiate(destoryEffect);
        effect.transform.position = transform.position;
        ParticleSystem.MainModule mainModule = effect.main;
        var blockColor = GetComponentInChildren<SpriteRenderer>().color;
        mainModule.startColor = blockColor;
        Destroy(effect, 3f);
        
        // score
        gameManager.AddScore(maxHealth);
        
        // score text
        var canvas = Instantiate(scoreTextCanvas);
        canvas.GetComponent<RectTransform>().anchoredPosition = transform.position;
        var scoreText = canvas.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.enabled = true;
        scoreText.text = $"+{maxHealth}";
        scoreText.color = blockColor;
        
        // screen shake
        ScreenShaker.Instance.ShakeCamera();
        
        Destroy(gameObject);
    }
}
