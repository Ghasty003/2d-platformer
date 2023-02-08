using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver(collision);
    }

    private void GameOver(Collision2D collision)
    {
        Collider2D collider = collision.GetContact(0).collider;

        if (collider.tag == "Enemy")
        {
            sprite.flipY = true;
            Vector3 position = new Vector3(Random.Range(40f, 70f), Random.Range(-40f, 40f), 0f);
            transform.position += position * Time.deltaTime;
            GetComponent<Collider2D>().enabled = false;
            Invoke("Restart", 1f);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "LevelUp")
        {
            Debug.Log("Finish");
        }
    }
}
