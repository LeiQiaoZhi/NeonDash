using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// x: [-18.34, 18.34]
// y: [-10, 9.98]
// z: -10

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public float spawnRate = 2;
    public float timer = 0;
    public float lowX, highX, lowY, highY, Z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    KeyValuePair<Vector2, Vector3> getRandomPosition(Vector3 centre)
    {
        Vector2 p = Vector2.zero;
        Vector3 dir = Vector3.zero;
        do
        {
            int id = Random.Range(0, 4);
            if (id == 0)
            {
                dir = Vector3.right;
                p = new Vector2(lowX, Random.Range(lowY, highY));
            }
            if (id == 1)
            {
                dir = Vector3.left;
                p = new Vector2(highX, Random.Range(lowY, highY));
            }
            if (id == 2)
            {
                dir = Vector3.up;
                p = new Vector2(Random.Range(lowX, highX), lowY);
            }
            if (id == 3)
            {
                dir = Vector3.down;
                p = new Vector2(Random.Range(lowX, highX), highY);
            }
        } while (Vector2.Distance(p, centre) < 3);
        return new KeyValuePair<Vector2, Vector3>(p, dir);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
            timer = timer + Time.deltaTime;
        else
        {
            PlayerInput player = FindObjectOfType<PlayerInput>();

            Vector3 v = Camera.main.ViewportToWorldPoint(Vector3.zero);
            lowX = v.x;
            lowY = v.y;
            v = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            highX = v.x;
            highY = v.y;
            Z = v.z;

            //var blockGO = Instantiate(block, getRandomPosition(player.transform.position), transform.rotation);
            
            timer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        //Camera.main.ViewportToWorldPoint(Vector3.zero);
        Gizmos.DrawWireSphere(Camera.main.ViewportToWorldPoint(Vector3.zero), 3);
        Gizmos.DrawWireSphere(Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)), 3);
        Gizmos.DrawWireSphere(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)), 3);
        Gizmos.DrawWireSphere(Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)), 3);
    }
}
