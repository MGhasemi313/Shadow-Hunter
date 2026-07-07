using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [Header(" FlyingEnemy Points")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;

    private Transform target;
    private SpriteRenderer spriteRenderer;

    private float leftX;
    private float rightX;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // پیدا کردن نقطه چپ و راست
        leftX = Mathf.Min(pointA.position.x, pointB.position.x);
        rightX = Mathf.Max(pointA.position.x, pointB.position.x);

        // حرکت اولیه به سمت نقطه راست
        target = (pointA.position.x > pointB.position.x) ? pointA : pointB;

        spriteRenderer.flipX = false;
    }

    private void Update()
    {
        // حرکت به سمت هدف
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        // رسیدن به سمت راست
        if (transform.position.x >= rightX)
        {
            target = (pointA.position.x < pointB.position.x) ? pointA : pointB;
            spriteRenderer.flipX = true;
        }
        // رسیدن به سمت چپ
        else if (transform.position.x <= leftX)
        {
            target = (pointA.position.x > pointB.position.x) ? pointA : pointB;
            spriteRenderer.flipX = false;
        }
    }

}
