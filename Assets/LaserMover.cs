using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMover : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float accRate = 15, timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < accRate)
            timer = timer + Time.deltaTime;
        else
        {
            moveSpeed = moveSpeed + 0.1f;
            timer = 0;
        }
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
    }
}
