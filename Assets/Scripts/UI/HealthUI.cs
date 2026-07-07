using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Hearts")]
    [SerializeField] private Image[] hearts;


    private PlayerHealth playerHealth;


    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

        UpdateHealth();
    }


    void Update()
    {
        UpdateHealth();
    }


    void UpdateHealth()
    {
        int health = playerHealth.GetHealth();


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}