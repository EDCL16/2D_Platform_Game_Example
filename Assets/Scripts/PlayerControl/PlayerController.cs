using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] int playerHealth = 5;
    [SerializeField] CheckGrounded checkGrounded;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] HealthBar playerHealthBar;
    private SoundEffectManager soundEffectManager;
    private Rigidbody2D rb;
    private Animator animator;
    private float xInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        checkGrounded = FindFirstObjectByType<CheckGrounded>();
        soundEffectManager = FindFirstObjectByType<SoundEffectManager>();
        playerHealthBar = GetComponentInChildren<HealthBar>();//從子物件找腳本
        playerHealthBar.SetMax(playerHealth);
        playerHealthBar.SetCurrent(playerHealth);
    }
    void Update()// 輸入適合用Update
    {
        xInput = Input.GetAxis("Horizontal");

        // 跳躍
        if (Input.GetButtonDown("Jump") && checkGrounded.IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void FixedUpdate() // 處理物理移動
    {
        Vector2 speed = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        MovePlayer(speed);
        SetPlayerRunAnimation();
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
    void SetPlayerRunAnimation()
    {
        bool isRunning = math.abs(rb.linearVelocityX) > 0.1f;
        animator.SetBool("isRunning", isRunning);
    }

    public void PlayerHurt()
    {
        animator.SetTrigger("Hurt");
        soundEffectManager.PlaySoundEffect(hurtSound);
        playerHealth--;
        playerHealthBar.SetCurrent(playerHealth);
    }
}
