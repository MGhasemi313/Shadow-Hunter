using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerHealth : MonoBehaviour
// {
//     [Header("Health")]
//     [SerializeField] private int maxHealth = 3;

//     private int currentHealth;

//     private Animator animator;

//     private bool isDead;

//     void Start()
//     {
//         currentHealth = maxHealth;
//         animator = GetComponent<Animator>();
//     }

//     public void TakeDamage(int damage)
//     {
//         if (isDead)
//             return;
//         if (Input.GetKeyDown(KeyCode.H))
//         {
//             TakeDamage(1);
//         }
//         currentHealth -= damage;

//         animator.SetTrigger("Hurt");

//         if (currentHealth <= 0)
//         {
//             Die();
//         }

//         Debug.Log("Player Health : " + currentHealth);
//     }

//     void Die()
//     {
//         isDead = true;

//         animator.SetTrigger("Die");

//         Invoke(nameof(GameOver), 1.5f);
//     }

//     void GameOver()
//     {
//         SceneManager.LoadScene("GameOver");
//     }

//     public int GetHealth()
//     {
//         return currentHealth;
//     }

//     public int GetMaxHealth()
//     {
//         return maxHealth;
//     }
// }

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;
    private Animator animator;
    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {


        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        if (animator != null)
            animator.SetTrigger("Hurt");

        if (currentHealth == 0)
        {
            Die();
        }
        if (isDead) return;
        Debug.Log("Player Health: " + currentHealth);
    }

    void Die()
    {
        isDead = true;

        if (animator != null)
            animator.SetTrigger("Die");

        Invoke(nameof(GameOver), 1.5f);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}