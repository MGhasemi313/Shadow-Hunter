using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Animator animator;

    [Header("Shoot Settings")]
    [SerializeField] private float fireRate = 0.25f;

    private float nextFireTime;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.time < nextFireTime)
            return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F))
        {

            Shoot();
            
        }
    }

    void Shoot()
    {


        nextFireTime = Time.time + fireRate;

        animator.SetTrigger("Shoot");

    }
    public void SpawnBullet()
    {
        Debug.Log("SpawnBullet Called");
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity);

        int dir = spriteRenderer.flipX ? -1 : 1;

        if (dir == -1)
        {
            bullet.transform.localScale = new Vector3(-0.1f, 0.1f, 1);
        }

        bullet.GetComponent<Bullet>().SetDirection(dir);
    }
}