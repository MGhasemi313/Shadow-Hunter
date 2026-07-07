using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 1;

    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>()
            .TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}