using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public LaserMover laser;
    public float moveSpeed;
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        laser = FindObjectOfType<LaserMover>();
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
        if (transform.position.y - transform.localScale.y / 2 <= laser.transform.position.y &&
            transform.position.y + transform.localScale.y / 2 >= laser.transform.position.y)
            Destroy(gameObject);
        transform.position = transform.position + (dir * moveSpeed) * Time.deltaTime;
    }
}
