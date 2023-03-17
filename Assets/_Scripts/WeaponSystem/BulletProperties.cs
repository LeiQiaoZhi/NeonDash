using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/BulletProperty")]
public class BulletProperties : ScriptableObject
{
    public int damage = 1;
    public float speed;
    public float lifeTime;
    [Header("Division")] public float numBulletsDivided;
    public float angleBetweenBullets;
    public float delayBeforeDivision;
    public int numRecursiveDivision = 1;
}