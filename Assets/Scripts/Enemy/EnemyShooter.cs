using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform player;

    public GameObject bulletPrefab;

    public Transform firePoint;

    public float shootInterval = 2f;

    private float timer;

    void Update()
    {
        if (player == null)
            return;


        timer += Time.deltaTime;


        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        Vector2 direction =
        (player.position - firePoint.position).normalized;


        GameObject bullet =
        Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity);


        bullet.GetComponent<EnemyBullet>()
        .SetDirection(direction);
    }
}