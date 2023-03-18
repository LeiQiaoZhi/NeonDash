using System.Collections;
using UnityEngine;

public class Weapon : ScriptableObject
{
    public GameObject bulletPrefab;
    public float firePointOffset = 0.5f;
    public BulletProperties startingBulletProperties;
    public WeaponProperties startingWeaponProperties;
    [Header("Runtime")]
    public BulletProperties bulletProperties;
    public WeaponProperties weaponProperties;

    // ReSharper disable Unity.PerformanceAnalysis
    public virtual void ShootBullet(WeaponHolder holder)
    {
        for (int directionIndex = 0; directionIndex < 4; directionIndex++)
        {
            int numBullets = weaponProperties.numBulletsTDLR[directionIndex];
            for (int i = 0; i < numBullets; i++)
            {
                Vector2 direction = weaponProperties.GetDirection(directionIndex, holder.transform).normalized;
                Vector2 tangentRight = new Vector2(direction.y, -direction.x).normalized;
                Vector2 bulletPos =
                    holder.transform.position
                    + (Vector3)direction * firePointOffset
                    + (Vector3)tangentRight * weaponProperties.GetHorizontalOffset(i, numBullets);

                var bullet = Instantiate(bulletPrefab, bulletPos, holder.transform.rotation);
                bullet.GetComponent<Bullet>().Init(weaponProperties.GetRandomDirectionInRange(direction),bulletProperties);
            }
        }

        holder.StartCoroutine(KnockBack(holder.gameObject.GetComponentInParent<Rigidbody2D>(), -holder.transform.up, 0.1f));
    }

    protected IEnumerator KnockBack(Rigidbody2D rb, Vector2 direction, float time)
    {
        float normalAcc = rb.GetComponent<Movement>().runtimeMovementSettings.accleration;
        rb.GetComponent<Movement>().runtimeMovementSettings.accleration /= 10;
        float until = Time.time + time;
        while (Time.time < until)
        {
            rb.velocity += direction * (weaponProperties.knockBack * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        rb.GetComponent<Movement>().runtimeMovementSettings.accleration *= 10;
    }
}