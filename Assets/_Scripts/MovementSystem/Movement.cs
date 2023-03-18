using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public MovementSettings startingMovementSettings;
    public MovementSettings runtimeMovementSettings;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        CopyMovementSettingsToRuntime();
    }

    private void CopyMovementSettingsToRuntime()
    {
        string jsonMovement = JsonUtility.ToJson(startingMovementSettings);
        JsonUtility.FromJsonOverwrite(jsonMovement,runtimeMovementSettings);
    }

    public void MoveInDirection(Vector2 direction)
    {
        // _rb.velocity = direction.normalized * movementSettings.moveSpeed;
        _rb.velocity += direction.normalized * (runtimeMovementSettings.accleration * Time.deltaTime);
        _rb.velocity = _rb.velocity.normalized * Mathf.Clamp(_rb.velocity.magnitude, 0, runtimeMovementSettings.moveSpeed);

    }

    public void RotateTowards(Vector2 target)
    {
        // XLogger.Log("rotate");
        // var direction = (Vector2)((Vector3)target - transform.position).normalized;
        // var angle = Mathf.Acos(Vector2.Dot(direction, transform.right))*Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        RotateHelper.SmoothRotateTowards(_rb,target,transform.up,runtimeMovementSettings.rotationSpeed);
    }
}