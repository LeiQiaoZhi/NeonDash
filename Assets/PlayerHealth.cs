using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerHealth : Health
{
    public RectTransform heartBar;
    public GameObject heartItem;
    public GameObject notFullHeartItem;

    private void Start()
    {
        foreach (GameObject child in heartBar)
        {
            Destroy(child);
        }
        
        for (int i = 0; i < maxHealth; i++)
        {
            Instantiate(heartItem, heartBar);
        }
    }

    protected override void Die()
    {
        XLogger.LogWarning(Category.Player, "Player has died.");
    }

    public override void ChangeHealth(int change, GameObject from)
    {
        base.ChangeHealth(change, from);
        foreach (RectTransform child in heartBar)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(heartItem, heartBar);
        }
        for (int i = 0; i < maxHealth-currentHealth; i++)
        {
            Instantiate(notFullHeartItem, heartBar);
        }
    }
}