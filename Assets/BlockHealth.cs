using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : Health
{
    public ParticleSystem destoryEffect;

    public override void ChangeHealth(int change, GameObject from)
    {
        base.ChangeHealth(change, from);
    }

    protected override void Die()
    {
        var effect = Instantiate(destoryEffect);
        effect.transform.position = transform.position;
        Destroy(effect, 3f);
        Destroy(gameObject);
    }
}
