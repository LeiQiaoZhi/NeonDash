using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLDRBulletPowerUp : Powerup
{
    public int directionIndexTLDR;
    public int changeAmount;
    protected override void OnPickUp(Collider2D col)
    {
        base.OnPickUp(col);
        PowerupManager.Instance.ChangeBulletNumberTLDR(changeAmount, directionIndexTLDR);
    }
}
