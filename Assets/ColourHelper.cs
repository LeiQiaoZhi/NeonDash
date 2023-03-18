using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColourHelper 
{
    public static Color GetRandomColour(float intensity)
    {
        var colorVec = new Vector3(Random.value, Random.value, Random.value);
        colorVec = colorVec.normalized * intensity;
        return new Color(colorVec.x, colorVec.y, colorVec.z); 
    }
}
