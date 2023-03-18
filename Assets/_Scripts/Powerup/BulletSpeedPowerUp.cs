using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedPowerUp : Powerup
{
    public float bulletSpeedMultiplier;
    protected override void OnPickUp(Collider2D col)
    {
        base.OnPickUp(col);
        PowerupManager.Instance.MultiplyBulletSpeed(bulletSpeedMultiplier);
    }
}
