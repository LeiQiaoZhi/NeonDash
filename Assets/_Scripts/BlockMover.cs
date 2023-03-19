using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 dir;
    public Transform spriteHolder;

    // Start is called before the first frame update
    void Start()
    {
        spriteHolder.transform.localScale = new Vector2(Random.Range(1.0f, 4.0f), Random.Range(1.0f, 4.0f));
        // laser = FindObjectOfType<LaserMover>();
        //transform.localScale = new Vector2(1, 1);
    }

    public void SetMove(Vector3 direction, float start, float end)
    {
        dir = direction;
        moveSpeed = Random.Range(start, end);
    }

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.y - spriteHolder.transform.localScale.y / 2 <= laser.transform.position.y &&
        //     transform.position.y + spriteHolder.transform.localScale.y / 2 >= laser.transform.position.y)
        //     Destroy(gameObject);
        // if (transform.position.y < laser.transform.position.y)
        //     Destroy(gameObject);
        transform.position += dir * (moveSpeed * Time.deltaTime);
    }
}
