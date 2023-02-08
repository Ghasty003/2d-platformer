using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    private GameObject Enemy;
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
        if (Enemy.transform.position.y < -10f)
        {
            Destroy(Enemy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy.GetComponent<SpriteRenderer>().flipY = true;
        Enemy.GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Vector3 movement = new Vector3(Random.Range(40f, 70f), Random.Range(-40f, 40f), 0f);
        Enemy.transform.position += movement * Time.deltaTime;
    }
}
