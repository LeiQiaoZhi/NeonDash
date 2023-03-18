using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWorldCameraOnStart : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
