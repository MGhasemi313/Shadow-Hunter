using UnityEngine;


public class BossAttack : MonoBehaviour
{
    public Transform player;

    public GameObject bulletPrefab;

    public Transform firePoint;

    public float time = 2;

    float timer;



    void Update()
    {

        timer += Time.deltaTime;


        if (timer >= time)
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