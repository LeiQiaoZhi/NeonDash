using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/LaserWeapon")]
public class LaserWeapon : Weapon
{
    public float range;
    public float lifetime;
    [SerializeField] private LayerMask targetLayerMask;
    LineRenderer laserBeam;

    public override void ShootBullet(WeaponHolder holder)
    {
        for (int directionIndex = 0; directionIndex < 4; directionIndex++)
        {
            int numBullets = weaponProperties.numBulletsTDLR[directionIndex];
            for (int i = 0; i < numBullets; i++)
            {
                XLogger.Log(Category.Weapon, "Laser Weapon Fired");
                
                Vector2 direction = weaponProperties.GetDirection(directionIndex, holder.transform).normalized;
                
                var transform = holder.transform;
                var laser = Instantiate(bulletPrefab);
                Destroy(laser,lifetime);
                laserBeam = laser.GetComponentInChildren<LineRenderer>();

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range, targetLayerMask);

                laserBeam.enabled = true;
                Vector2 firePos = transform.position + (Vector3)direction * firePointOffset;
                laserBeam.SetPosition(0, firePos);

                if (hit.collider != null)
                {
                    XLogger.Log(Category.Weapon, $"laser hit {hit.collider.gameObject.name}");
                    laserBeam.SetPosition(1, hit.point);
                }
                else
                {
                    laserBeam.SetPosition(1, firePos + direction * range);
                }
            }
        }

        holder.StartCoroutine(KnockBack(holder.gameObject.GetComponentInParent<Rigidbody2D>(), -holder.transform.up,
            0.1f));
    }
}