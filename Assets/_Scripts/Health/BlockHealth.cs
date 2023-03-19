using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockHealth : Health
{
    public ParticleSystem destoryEffect;
    public TextMeshProUGUI healthText;
    public Canvas scoreTextCanvas;
    public GameObject residuePrefab;

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

        if (from.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound("HitBlock");
            ScreenShaker.Instance.ShakeCamera(1f,2f,0.1f);
        }

    }

    protected override void Die(GameObject from)
    {
        // sound
        AudioManager.Instance.PlaySound("BlockDestroyed");
        
        // particle effect
        var effect = Instantiate(destoryEffect);
        effect.transform.position = transform.position;
        ParticleSystem.MainModule mainModule = effect.main;
        var blockColor = GetComponentInChildren<SpriteRenderer>().color;
        mainModule.startColor = blockColor;
        Destroy(effect, 3f);

        // residue
        var residue = Instantiate(residuePrefab, transform.position,
            Quaternion.AngleAxis(Random.Range(0, 180), Vector3.forward));
        residue.GetComponent<SpriteRenderer>().color = blockColor;

        if (from.CompareTag("Player"))
        {
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
        }

        Destroy(gameObject);
    }
}