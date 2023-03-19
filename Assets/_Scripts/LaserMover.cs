using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMover : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float accRate = 5, timer = 0, dv = 0.2f;

    private void Start()
    {
        // AudioManager.Instance.PlaySound("Laser");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < accRate)
            timer = timer + Time.deltaTime;
        else
        {
            moveSpeed = moveSpeed + dv;
            timer = 0;
        }
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
    }
}
