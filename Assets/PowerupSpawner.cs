using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] powerups;
    public GameObject laser;
    public float spawnRate = 2, timer = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
            timer = timer + Time.deltaTime;
        else
        {
            float lowX, highX, lowY, highY;
            Vector3 v = Camera.main.ViewportToWorldPoint(Vector3.zero);
            lowX = v.x;
            lowY = v.y;
            v = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            highX = v.x;
            highY = v.y;
            Instantiate(powerups[Random.Range(0, 7)],
                        new Vector2(Random.Range(lowX - 40, highX + 40), Random.Range(highY, highY + 40)),
                        transform.rotation);
            timer = 0;
        }
    }
}
