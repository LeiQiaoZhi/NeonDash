using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthPowerUp : Powerup
{
    public int maxHealthIncreaseAmount = 1 ;
    protected override void OnPickUp(Collider2D col)
    {
        base.OnPickUp(col);
        PowerupManager.Instance.ChangePlayerMaxHealth(maxHealthIncreaseAmount);
    }
}
