using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifeTime = 3f;

    private int direction = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(int dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(1);

            Destroy(gameObject);
        }
        
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHealth>()
            .TakeDamage(1);

            Destroy(gameObject);
        }
    }
}