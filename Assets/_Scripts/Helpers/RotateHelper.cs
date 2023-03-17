using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RotateHelper  
{
    /// <summary>
    /// Smooth -- faster when angle between is large
    /// <para>- is affected by angular drag</para>
    /// </summary>
    /// <param name="rb">the RB2D to apply rotation</param>
    /// <param name="targetPos">rotate towards target</param> 
    /// <param name="referenceDirection">which direction to align to target, e.g. <c>tranform.right</c></param>
    public static void SmoothRotateTowards(Rigidbody2D rb, Vector2 targetPos, Vector2 referenceDirection  ,float rotateSpeed)
    {
        var direction = (Vector2)((Vector3)targetPos - rb.transform.position).normalized;
        float rotateAmount = Vector3.Cross(direction, referenceDirection).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
    }

    /// <summary>
    /// returns angle from 0 to 180 degrees
    /// <code>
    /// AngleBetween(transform.position, target.position, transform.right)
    /// </code>
    /// </summary>
    /// <returns></returns>
    public static float AngleBetween(Vector3 originPosition, Vector3 targetPosition, Vector3 referenceDirection)
    {
        var direction = (Vector2)(targetPosition - originPosition).normalized;
        var angle = Mathf.Acos(Vector2.Dot(direction, referenceDirection.normalized))*Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle += 180;
        }

        return angle;
    }

    public static Vector2 Rotate(Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);
        return new Vector2(cos * v.x - sin * v.y, sin * v.x + cos * v.y);
    }

}