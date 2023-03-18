using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    protected override void Die()
    {
        XLogger.LogWarning(Category.Player, "Player has died.");
    }
}
