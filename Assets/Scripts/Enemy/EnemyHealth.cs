using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 5;
    [SerializeField] HealthBar healthBar;

    void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();//從子物件找腳本
        healthBar.SetMax(enemyHealth);
        healthBar.SetCurrent(enemyHealth);
    }

    public void Hurt()
    {
        enemyHealth--;
        Die();
        healthBar.SetCurrent(enemyHealth);
    }
    void Die()
    {
        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
