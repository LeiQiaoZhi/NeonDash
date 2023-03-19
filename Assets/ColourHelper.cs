using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColourHelper 
{
    public static Color GetRandomColour(float brightness, float saturation, float alpha=1)
    {
        var color = Color.HSVToRGB(Random.value, saturation, brightness);
        color.a = alpha;
        return color;
        // var colorVec = new Vector3(Random.value, Random.value, Random.value);
        // colorVec = colorVec.normalized * intensity;
        // return new Color(colorVec.x, colorVec.y, colorVec.z); 
    }
}
