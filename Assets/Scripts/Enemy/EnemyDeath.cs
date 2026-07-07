using UnityEngine;
using System;

public class EnemyDeath : MonoBehaviour
{

    public Action OnDeath;


    public void Die()
    {
        OnDeath?.Invoke();

        Destroy(gameObject);
    }

}