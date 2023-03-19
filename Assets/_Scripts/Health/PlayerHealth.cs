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
    public GameEvent gameOverEvent;

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

    protected override void Die(GameObject from)
    {
        XLogger.LogWarning(Category.Player, "Player has died.");
        gameOverEvent.Raise();
    }

    public override void ChangeHealth(int change, GameObject from)
    {
        if (change < 0)
            AudioManager.Instance.PlaySound("LoseLife");
        base.ChangeHealth(change, from);
        foreach (RectTransform child in heartBar)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(heartItem, heartBar);
        }
        for (int i = 0; i < maxHealth-Mathf.Max(0,currentHealth); i++)
        {
            Instantiate(notFullHeartItem, heartBar);
        }
    }
}
