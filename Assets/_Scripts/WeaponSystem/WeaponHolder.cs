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