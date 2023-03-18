using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MeterObject : MonoBehaviour
{
    public bool followX;
    public bool followY;

    [Header("Graphics")] 
    public SpriteRenderer leftSprite;
    public SpriteRenderer rightSprite;
    public Light2D leftLight;
    public Light2D rightLight;
    public TextMeshProUGUI meterText;

    public float moveThreshholdX = 20;
    float moveThreshholdY;

    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        float height = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y -
                       Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        moveThreshholdY = height/2 + 1;
        
        // random colour
        var color = ColourHelper.GetRandomColour(1);
        leftSprite.color = color;
        // leftLight.color = color;
        rightSprite.color = color;
        // rightLight.color = color;
        meterText.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (followX || followY)
        {
            if (Mathf.Abs(transform.position.x - target.position.x) < moveThreshholdX ||
                transform.position.y - target.position.y < moveThreshholdY)
                return;

            transform.position = new Vector3(
                followX ? target.transform.position.x : transform.position.x,
                followY ? target.transform.position.y : transform.position.y,
                transform.position.z
            );
        }
    }
}