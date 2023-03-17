using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public LayerMask pickupLayer;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, pickupLayer))
        {
            OnPickUp(col);
            Destroy(gameObject);
        }
    }
    protected virtual void OnPickUp(Collider2D col)
    {
        XLogger.Log(Category.PowerUp, $"{gameObject.name} picked up by {col.gameObject.name}");
    }
}
