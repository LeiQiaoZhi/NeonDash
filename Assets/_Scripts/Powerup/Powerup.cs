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
    public GameObject indicator;
    public LayerMask destoryLayer;

    protected virtual void Start()
    {
        pickupText.enabled = false;
        pickupText.color = textColor;
        pickupText.text = pickupLine;
        if (indicator)
            indicator.GetComponent<SpriteRenderer>().color = textColor;
    }

    protected virtual void FixedUpdate()
    {
        var viewPortPos = Camera.main.WorldToViewportPoint(transform.position);
        if (!InsideScreen(viewPortPos))
        {
            indicator.SetActive(true);
            var indicatorViewPortPos = new Vector2(
                Mathf.Clamp(viewPortPos.x, 0, 1),
                Mathf.Clamp(viewPortPos.y, 0, 1)
            );
            var indicatorPos = Camera.main.ViewportToWorldPoint(indicatorViewPortPos);
            indicatorPos.z = 0;
            indicator.transform.position = indicatorPos;
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    private bool InsideScreen(Vector3 viewPortPos)
    {
        if (viewPortPos.x < 0 || viewPortPos.x > 1 || viewPortPos.y > 1 || viewPortPos.y < 0)
            return false;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, pickupLayer))
        {
            OnPickUp(col);
            Destroy(gameObject, 3f);
        }
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, destoryLayer))
        {
            Destroy(gameObject);
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