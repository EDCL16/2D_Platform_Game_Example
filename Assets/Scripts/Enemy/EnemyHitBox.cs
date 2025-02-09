using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().PlayerHurt();
        }
    }
}
