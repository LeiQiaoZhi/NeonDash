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

    public virtual void SetMaxHealth(int newMaxHealth, bool setCurrentHealth = true)
    {
        maxHealth = newMaxHealth;
        if (setCurrentHealth)
            currentHealth = maxHealth;
    }

    public virtual void ChangeHealth(int change, GameObject from)
    {
        currentHealth = Mathf.Clamp(currentHealth+change,0,maxHealth);
        if (currentHealth <= 0)
        {
            Die(from);
        }
    }

    protected abstract void Die(GameObject from);
}
