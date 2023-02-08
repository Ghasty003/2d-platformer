using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject[] points;
    private SpriteRenderer sprite;
    private int currentPoint = 0;
    private float speed = 1f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (transform.position.x == points[currentPoint].transform.position.x)
        {
            currentPoint++;
        }

        if (currentPoint >= points.Length)
        {
            currentPoint = 0;
        }

        if (currentPoint == 1)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        Vector3 m = new Vector3(points[currentPoint].transform.position.x, transform.position.y, 0f);
        transform.position = Vector2.MoveTowards(transform.position, m, Time.deltaTime * speed);
    }
}
