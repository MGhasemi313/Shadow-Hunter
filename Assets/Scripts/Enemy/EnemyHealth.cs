using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.AddScore(100);
        Destroy(gameObject);
    }
}