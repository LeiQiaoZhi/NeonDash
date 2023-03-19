using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRangePowerUp : Powerup
{
    public float bulletRangeMultiplier = 1.2f;
    protected override void OnPickUp(Collider2D col)
    {
        base.OnPickUp(col);
        PowerupManager.Instance.MultiplyBulletLifeTime(bulletRangeMultiplier);
    }
}
