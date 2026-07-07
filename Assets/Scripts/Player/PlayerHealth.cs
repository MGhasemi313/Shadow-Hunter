
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    private Animator animator;

    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

        Debug.Log("Player Health : " + currentHealth);
    }

    void Die()
    {
        isDead = true;

        animator.SetTrigger("Die");

        Invoke(nameof(GameOver), 1f);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
