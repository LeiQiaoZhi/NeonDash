using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDivision : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool initialBullet = true;

    private int numRecursiveDivision;
    private BulletProperties bulletProperties;
    

    public void SetNumRecursive(int num)
    {
        numRecursiveDivision = num;
        initialBullet = false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator Init()
    {
        bulletProperties = GetComponent<Bullet>().GetBulletProperty();
        rb = GetComponent<Rigidbody2D>();
        if (bulletProperties.numBulletsDivided <= 1)
        {
            yield break;
        }
        if (initialBullet)
        {
            numRecursiveDivision = bulletProperties.numRecursiveDivision;
        }
        yield return new WaitForSeconds(bulletProperties.delayBeforeDivision);
        
        // divide the bullet
        for (int i = 0; i < bulletProperties.numBulletsDivided; i++)
        {
            var bulletGO = Instantiate(gameObject);
            var bulletDivision = bulletGO.GetComponent<BulletDivision>();
            bulletDivision.SetNumRecursive(numRecursiveDivision-1);
            if (numRecursiveDivision <= 1)
            {
                XLogger.Log("Bullet Division Finished");
                bulletDivision.enabled = false;
            }

            float angle = -(bulletProperties.angleBetweenBullets * (bulletProperties.numBulletsDivided - 1)) / 2 +
                          i * bulletProperties.angleBetweenBullets;
            Vector2 direction = RotateHelper.Rotate(rb.velocity, angle);
            var bullet = bulletGO.GetComponent<Bullet>();
            bullet.Init(direction,bulletProperties);
        }
        
        Destroy(gameObject);
    }
}
