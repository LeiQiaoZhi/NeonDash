using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// x: [-18.34, 18.34]
// y: [-10, 9.98]
// z: -10

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public float spawnRate = 1, accelerRate = 20;
    public float timerSpawn = 0, timerSpeed = 0;
    public float lowX, highX, lowY, highY, Z;
    public float minSpeed = 10, maxSpeed = 15;

    private PlayerInput player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerInput>();
    }

    KeyValuePair<Vector2, Vector3> getRandomPosition(Vector3 centre)
    {
        Vector2 p = Vector2.zero;
        Vector3 dir = Vector3.zero;
        do
        {
            int id = Random.Range(0, 3);
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
                dir = Vector3.down;
                p = new Vector2(Random.Range(lowX, highX), highY);
            }
        } while (Vector2.Distance(p, centre) < 3);

        return new KeyValuePair<Vector2, Vector3>(p, dir);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSpeed < accelerRate)
            timerSpeed = timerSpeed + Time.deltaTime;
        else
        {
            minSpeed = minSpeed + 0.05f;
            maxSpeed = maxSpeed + 0.05f;
            spawnRate = spawnRate * 0.95f;
            timerSpeed = 0;
        }

        if (timerSpawn < spawnRate)
            timerSpawn = timerSpawn + Time.deltaTime;
        else
        {
            Vector3 v = Camera.main.ViewportToWorldPoint(Vector3.zero);
            lowX = v.x;
            lowY = v.y;
            v = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            highX = v.x;
            highY = v.y;
            Z = v.z;

            var (position, dir) = getRandomPosition(player.transform.position);

            CreateBlock(position, dir, minSpeed, maxSpeed);
            timerSpawn = 0;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void CreateBlock(Vector2 position, Vector3 dir, float minBlockSpeed, float maxBlockSpeed)
    {
        var blockGO = Instantiate(block, position, transform.rotation);
        var blockMover = blockGO.GetComponent<BlockMover>();
        blockMover.SetMove(dir, minBlockSpeed, maxBlockSpeed);
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