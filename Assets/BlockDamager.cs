using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDamager : MonoBehaviour
{
    public LayerMask playerLayer;
    public int damage;
    public bool destorySelfOnHit;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, playerLayer))
        {
            XLogger.Log(Category.Block,$"{gameObject.name} hit {col.gameObject.name}");
            // deal damage to player
            var playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerHealth.ChangeHealth(-damage,gameObject);

            if (destorySelfOnHit)
            {
                var health = GetComponentInParent<Health>();
                health.ChangeHealth(-health.maxHealth,gameObject);
            }
        }
    }
}
