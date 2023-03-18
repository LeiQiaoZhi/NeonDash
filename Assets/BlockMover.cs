using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerInput player = FindObjectOfType<PlayerInput>();
        //float lowX, highX, lowY, highY;
        //Vector3 v = Camera.main.ViewportToWorldPoint(Vector3.zero);
        //lowX = v.x;
        //lowY = v.y;
        //v = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        //highX = v.x;
        //highY = v.y;
        //if (transform.position.x <= lowX)
        //    dir = Vector3.right;
        //if (transform.position.x >= highX)
        //    dir = Vector3.left;
        //if (transform.position.y <= lowY)
        //    dir = Vector3.up;
        //if (transform.position.y >= highY)
        //    dir = Vector3.down;
        transform.localScale = new Vector2(Random.Range(1.0f, 4.0f), Random.Range(1.0f, 4.0f));
        //transform.localScale = new Vector2(1, 1);
    }

    public void SetMove(Vector3 dir, float start, float end)
    {
        this.dir = dir;
        this.moveSpeed = Random.Range(start, end);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (dir * moveSpeed) * Time.deltaTime;
    }
}
