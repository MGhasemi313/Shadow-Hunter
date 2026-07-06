using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            playerHealth.TakeDamage(enemy.damage);
        }
    }
}