using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDivisionPowerup : Powerup
{
    public Color playerChangedToColor;
    public int numBulletDividedIncrease = 2;
    public int numDivisionRecursionIncrease = 2;
    public float angleBetweenBullets = 20;
    public float delayBeforeDivision = 0.2f;
    public float bulletLifetimeMultiplier = 0.9f;
    public float effectLifeTime = 4f;

    protected override void OnPickUp(Collider2D col)
    {
        col.GetComponent<PlayerAppearance>().ChangeColor(playerChangedToColor,effectLifeTime);
        StartCoroutine(TempEffect());
    }

    private IEnumerator TempEffect()
    {
        destoryLayer = new LayerMask();
        PowerupManager.Instance.BulletDivide(numBulletDividedIncrease, angleBetweenBullets, delayBeforeDivision,
            numDivisionRecursionIncrease);
        PowerupManager.Instance.MultiplyBulletLifeTime(bulletLifetimeMultiplier);
        yield return new WaitForSeconds(effectLifeTime);
        XLogger.Log(Category.PowerUp,"restoring properties");
        PowerupManager.Instance.BulletDivide(-numBulletDividedIncrease, angleBetweenBullets, delayBeforeDivision,
            numBulletDividedIncrease);
        PowerupManager.Instance.MultiplyBulletLifeTime(1 / bulletLifetimeMultiplier);
        Destroy(gameObject);
    }
}