using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedPowerUp : Powerup
{
    public float secondsBetweenFireMultiplier;
    protected override void OnPickUp(Collider2D col)
    {
        base.OnPickUp(col);
        PowerupManager.Instance.MultiplyAttackSpeed(secondsBetweenFireMultiplier);
    }
}
