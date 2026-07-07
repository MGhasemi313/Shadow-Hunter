using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 20;

    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Boss HP : " + currentHealth);


        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        GetComponent<Animator>()
       .SetTrigger("Die");


        Invoke(nameof(Win), 2);

    }
    void Win()
    {
        SceneManager.LoadScene("Victory");
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}