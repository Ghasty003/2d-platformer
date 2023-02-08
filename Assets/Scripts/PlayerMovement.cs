using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D col;
    private SpriteRenderer sprite;
    private Animator anim;
    private enum MovementState { idle, running };
    [SerializeField] private LayerMask groundedLayer;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded())
        {
            rigidbody2d.velocity = new Vector2(0, 12f);
        }

        rigidbody2d.velocity = new Vector2(horizontalInput * 5, rigidbody2d.velocity.y);

        if (transform.position.y < -10f)
        {
            Invoke("Restart", 1f);
        }

        UpdateAnimationState();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (horizontalInput != 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (horizontalInput < 0f)
        {
            sprite.flipX = true;

        }
        else if (horizontalInput > 0f)
        {
            sprite.flipX = false;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, groundedLayer);
    }

}
