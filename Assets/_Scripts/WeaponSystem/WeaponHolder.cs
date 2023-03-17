using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    public SpriteRenderer weaponSpriteRenderer;
    private float nextFireTime;

    public void Fire()
    {
        if (Time.time < nextFireTime)
        {
            return;
        }
        
        weapon.ShootBullet(this);
        
        nextFireTime = Time.time + weapon.weaponProperties.secondsBetweenFire;
    }
}