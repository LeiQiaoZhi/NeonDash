using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public bool followX;
    public bool followY;

    // Update is called once per frame
    void Update()
    {
        if (followX || followY)
        {
            transform.position = new Vector3(
                followX ? target.transform.position.x : transform.position.x,
                followY ? target.transform.position.y : transform.position.y,
                transform.position.z
            );
        }
    }
}
