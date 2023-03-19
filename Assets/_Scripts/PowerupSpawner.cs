using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerupItem
{
    public GameObject powerup;
    public float relProb;
}

public class PowerupSpawner : MonoBehaviour
{
    public PowerupItem[] powerups;
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
            timer += Time.deltaTime;
        else
        {
            float lowX, highX, lowY, highY;
            Vector3 v = Camera.main.ViewportToWorldPoint(Vector3.zero);
            lowX = v.x;
            lowY = v.y;
            v = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            highX = v.x;
            highY = v.y;

            int i;
            float tot = 0, sum = 0;
            for (i = 0; i < powerups.Length; i++)
                sum += powerups[i].relProb;
            float rand = Random.Range(0, sum);
            for (i = 0; (tot += powerups[i].relProb) < rand; i++);
            Instantiate(powerups[i].powerup,
                        new Vector2(Random.Range(lowX - 40, highX + 40), Random.Range(highY, highY + 40)),
                        transform.rotation);
            timer = 0;
        }
    }
}
