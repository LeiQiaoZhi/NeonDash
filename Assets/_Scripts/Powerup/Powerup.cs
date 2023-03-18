using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public LayerMask pickupLayer;
    [Header("Text Notification")] public string pickupLine;
    public TextMeshProUGUI pickupText;
    public Color textColor;

    protected virtual void Start()
    {
        pickupText.enabled = false;
        pickupText.color = textColor;
        pickupText.text = pickupLine;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, pickupLayer))
        {
            OnPickUp(col);
            Destroy(gameObject, 3f);
        }
    }

    protected virtual void OnPickUp(Collider2D col)
    {
        XLogger.Log(Category.PowerUp, $"{gameObject.name} picked up by {col.gameObject.name}");
        GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
        pickupText.enabled = true;
        pickupText.GetComponent<Animator>().Play("PickupText");
    }
}