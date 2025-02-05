using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    private bool isGrounded;

    public bool IsGrounded()
    {
        return isGrounded;
    }
    public void PlayerJumped()
    {
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
