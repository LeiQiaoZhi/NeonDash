using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    private float nextFireTime;

    private void Start()
    {
        // set weapon runtime properties to default ones
        CopyPropertiesToRuntime();
    }

    public void Fire()
    {
        if (Time.time < nextFireTime)
        {
            return;
        }
        
        weapon.ShootBullet(this);
        
        ScreenShaker.Instance.ShakeCamera(0.5f, 1f, 0.1f);
        
        nextFireTime = Time.time + weapon.weaponProperties.secondsBetweenFire;
    }

    public void CopyPropertiesToRuntime()
    {
        string jsonBullet = JsonUtility.ToJson(weapon.startingBulletProperties);
        JsonUtility.FromJsonOverwrite(jsonBullet,weapon.bulletProperties);
        string jsonWeapon = JsonUtility.ToJson(weapon.startingWeaponProperties);
        JsonUtility.FromJsonOverwrite(jsonWeapon,weapon.weaponProperties); 
    }
}