using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestorePowerUp : Powerup
{
    public int restoreAmount = 1;
    protected override void OnPickUp(Collider2D col)
    {
        base.OnPickUp(col);
        PowerupManager.Instance.ChangePlayerHealth(restoreAmount);
    }
}
