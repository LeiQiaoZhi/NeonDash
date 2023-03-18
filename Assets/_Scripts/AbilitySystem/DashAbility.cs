using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/DashAbility")]
public class DashAbility : Ability
{
    public float dashSpeedMultiplier;
    public GameObject dashShade;
    
    private float _normalSpeed;
    

    private Rigidbody2D _rb;
    public override void OnActivate(AbilityHolder abilityHolder)
    {
        _normalSpeed = abilityHolder.GetComponent<Movement>().runtimeMovementSettings.moveSpeed;
        abilityHolder.GetComponent<Movement>().runtimeMovementSettings.moveSpeed *= dashSpeedMultiplier;
        _rb = abilityHolder.GetComponent<Rigidbody2D>();
    }

    public override void WhenActive(AbilityHolder abilityHolder)
    {
        _rb.velocity = _rb.velocity.normalized * dashSpeedMultiplier;
        var shade = Instantiate(dashShade);
        shade.transform.position = abilityHolder.transform.position;
        Destroy(shade,3f);
    }

    public override void OnCoolDown(AbilityHolder abilityHolder)
    {
        abilityHolder.GetComponent<Movement>().runtimeMovementSettings.moveSpeed = _normalSpeed;
    }
}