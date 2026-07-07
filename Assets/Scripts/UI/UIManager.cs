using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text scoreText;

private void Start()
    {
        UpdateCoin(0);
        UpdateScore(0);
    }
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }
    public void UpdateCoin(int value)
    {
        coinText.text = "Coin : " + value;
    }
}