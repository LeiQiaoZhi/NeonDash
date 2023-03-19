using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int maxHealth;
    
    protected int currentHealth;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

    public virtual void ChangeHealth(int change, GameObject from)
    {
        currentHealth += change;
        if (currentHealth <= 0)
        {
            Die(from);
        }
    }

    protected abstract void Die(GameObject from);
}
