using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    [SerializeField] CheckGrounded checkGrounded;
    [SerializeField] SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        checkGrounded = FindFirstObjectByType<CheckGrounded>();
    }

    void Update()
    {
        // 水平移動
        float xInput = Input.GetAxis("Horizontal");
        Vector2 speed = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        MovePlayer(speed);

        // 跳躍
        if (Input.GetButtonDown("Jump") && checkGrounded.IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            checkGrounded.PlayerJumped();
        }
    }
    void MovePlayer(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
        Filp(velocity.x);
    }
    void Filp(float xVelocity)
    {
        if (xVelocity > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (xVelocity < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
