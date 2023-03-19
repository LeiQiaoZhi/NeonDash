using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private WeaponHolder weaponHolder;
    private Movement playerMovement;
    private PlayerHealth playerHealth;

    public static PowerupManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<Movement>();
        weaponHolder = playerMovement.GetComponentInChildren<WeaponHolder>();
        playerHealth = playerMovement.GetComponent<PlayerHealth>();
    }

    public void MultiplyAttackSpeed(float secondsBetweenFireMultiplier)
    {
        var weaponProperties = weaponHolder.weapon.weaponProperties;
        XLogger.Log(Category.PowerUp,
            $"Seconds between fire changed from {weaponProperties.secondsBetweenFire} to {weaponProperties.secondsBetweenFire * secondsBetweenFireMultiplier}");
        weaponProperties.secondsBetweenFire *= secondsBetweenFireMultiplier;
    }

    public void ChangeBulletNumberTDLR(int change, int directionIndexTDLR)
    {
        var weaponProperties = weaponHolder.weapon.weaponProperties;
        XLogger.Log(Category.PowerUp,
            $"num bullets in {weaponProperties.TDLRtoString(directionIndexTDLR)} increased from" +
            $" {weaponProperties.numBulletsTDLR[directionIndexTDLR]} to {weaponProperties.numBulletsTDLR[directionIndexTDLR] + change}");
        weaponProperties.numBulletsTDLR[directionIndexTDLR] += change;
    }

    public void MultiplyBulletSpeed(float changeInBulletSpeed)
    {
        var bulletProperties = weaponHolder.weapon.bulletProperties;
        XLogger.Log(Category.PowerUp,
            $"bullet speed increased from {bulletProperties.speed} to {bulletProperties.speed + changeInBulletSpeed}");
        bulletProperties.speed += changeInBulletSpeed;
    }

    public void ChangePlayerSpeed(float change)
    {
        XLogger.Log(Category.PowerUp,
            $"player movement speed increased from {playerMovement.runtimeMovementSettings.moveSpeed}"
            + $"to {playerMovement.runtimeMovementSettings.moveSpeed + change}");
        playerMovement.runtimeMovementSettings.moveSpeed += change;
    }

    public string GetStatsSummary()
    {
        var weaponProperties = weaponHolder.weapon.weaponProperties;
        var bulletProperties = weaponHolder.weapon.bulletProperties;
        var movementSettings = playerMovement.runtimeMovementSettings;
        var summary = "# Weapon Properties #\n" +
                      $"seconds between fire: {weaponProperties.secondsBetweenFire}s\n" +
                      $"inaccuracy angle range: {weaponProperties.bulletInaccuracyAngleRange} degrees\n" +
                      $"num bullets -- TOP:{weaponProperties.numBulletsTDLR[0]}, LEFT:{weaponProperties.numBulletsTDLR[1]}," +
                      $"DOWN:{weaponProperties.numBulletsTDLR[2]}, RIGHT:{weaponProperties.numBulletsTDLR[3]}\n" +
                      $"knockback: {weaponProperties.knockBack} | " +
                      $"halfwidth: {weaponProperties.halfWidth}\n" +
                      "# Bullet Properties #\n" +
                      $"damage: {bulletProperties.damage} | " +
                      $"speed: {bulletProperties.speed} | " +
                      $"lifetime: {bulletProperties.lifeTime}\n" +
                      $"angle between bullets: {bulletProperties.angleBetweenBullets}\n" +
                      $"delay before division: {bulletProperties.delayBeforeDivision} | " +
                      $"bullets divided: {bulletProperties.numBulletsDivided} | " +
                      $"num division recursion: {bulletProperties.numRecursiveDivision}\n" +
                      "# Player Movement #\n" + 
                      $"Move speed: {movementSettings.moveSpeed} | " +
                      $"Acceleration: {movementSettings.accleration} | " +
                      $"Rotation speed: {movementSettings.rotationSpeed}";
        return summary;
    }

    public void ChangePlayerHealth(int restoreAmount)
    {
        playerHealth.ChangeHealth(restoreAmount, gameObject);
    }

    public void BulletDivide(int numBulletDividedIncrease, float angleBetweenBullets, float delayBeforeDivision,
        int numDivisionRecursionIncrease)
    {
        var bulletProperties = weaponHolder.weapon.bulletProperties;
        bulletProperties.numBulletsDivided += numBulletDividedIncrease;
        bulletProperties.angleBetweenBullets = angleBetweenBullets;
        bulletProperties.delayBeforeDivision = delayBeforeDivision;
        bulletProperties.numRecursiveDivision = numDivisionRecursionIncrease;
    }

    public void MultiplyBulletLifeTime(float rangeMultiplier)
    {
        var bulletProperties = weaponHolder.weapon.bulletProperties;
        bulletProperties.lifeTime *= rangeMultiplier; 
    }
}