using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class BulletDivision : MonoBehaviour
{
    public BulletProperties bulletProperties;
    private Rigidbody2D rb;
    private bool initialBullet = true;

    private int numRecursiveDivision;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (initialBullet)
        {
            numRecursiveDivision = bulletProperties.numRecursiveDivision;
        }
    }

    public void SetNumRecursive(int num)
    {
        numRecursiveDivision = num;
        initialBullet = false;
    }

    private IEnumerator Start()
    {
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
            bullet.Init(direction);
        }
        
        Destroy(gameObject);
    }
}
