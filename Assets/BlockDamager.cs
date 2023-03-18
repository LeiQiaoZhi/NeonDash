using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDamager : MonoBehaviour
{
    public LayerMask targetLayer;
    public int damage;
    public bool destorySelfOnHit;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, targetLayer))
        {
            XLogger.Log(Category.Block,$"{gameObject.name} hit {col.gameObject.name}");
            // deal damage to player
            var health = col.gameObject.GetComponentInParent<Health>();
            health.ChangeHealth(-damage,gameObject);

            if (destorySelfOnHit)
            {
                var selfHealth = GetComponentInParent<Health>();
                selfHealth.ChangeHealth(-health.maxHealth,gameObject);
            }
        }
    }
}
