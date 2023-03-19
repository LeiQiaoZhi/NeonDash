using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDivisionPowerup : Powerup
{
    public int numBulletDividedIncrease = 2;
    public int numDivisionRecursionIncrease = 2;
    public float angleBetweenBullets = 20;
    public float delayBeforeDivision = 0.2f;
    public float bulletLifetimeMultiplier = 0.9f;
    public float effectLifeTime = 4f;

    protected override void OnPickUp(Collider2D col)
    {
        StartCoroutine(TempEffect());
    }

    private IEnumerator TempEffect()
    {
        PowerupManager.Instance.BulletDivide(numBulletDividedIncrease, angleBetweenBullets, delayBeforeDivision,
            numDivisionRecursionIncrease);
        PowerupManager.Instance.MultiplyBulletLifeTime(bulletLifetimeMultiplier);
        yield return new WaitForSeconds(effectLifeTime);
        PowerupManager.Instance.BulletDivide(-numBulletDividedIncrease, angleBetweenBullets, delayBeforeDivision,
            numBulletDividedIncrease);
        PowerupManager.Instance.MultiplyBulletLifeTime(1 / bulletLifetimeMultiplier);
        Destroy(gameObject);
    }
}