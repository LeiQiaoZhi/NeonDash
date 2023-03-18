using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedPowerUp : Powerup
{
    public float changeInPlayerSpeed;
    protected override void OnPickUp(Collider2D col)
    {
        base.OnPickUp(col);
        PowerupManager.Instance.ChangePlayerSpeed(changeInPlayerSpeed);
    }
}
