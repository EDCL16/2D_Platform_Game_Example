using UnityEngine;

public class Bullet : MonoBehaviour
{
    // [SerializeField] float speed = 1;
    // void Start()
    // {
    //     GetComponent<Rigidbody2D>().linearVelocityX = speed;
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponentInChildren<EnemyHealth>();
            enemyHealth.Hurt();
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
