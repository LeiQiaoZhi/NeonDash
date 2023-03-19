using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedWushuang : Powerup
{
    public Color playerChangedToColor;
    public float attackSpeedMultiplier = 0.1f;
    public float effectLifeTime = 4f;

    protected override void OnPickUp(Collider2D col)
    {
        col.GetComponent<PlayerAppearance>().ChangeColor(playerChangedToColor,effectLifeTime);
        StartCoroutine(TempEffect());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator TempEffect()
    {
        destoryLayer = new LayerMask();
        PowerupManager.Instance.MultiplyAttackSpeed(attackSpeedMultiplier);
        yield return new WaitForSeconds(effectLifeTime);
        PowerupManager.Instance.MultiplyAttackSpeed(1/attackSpeedMultiplier);
        Destroy(gameObject);
    }
}