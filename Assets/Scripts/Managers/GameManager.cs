using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public void AddScore(int value)
    {
        score += value;
        UIManager.Instance.UpdateScore(score);
        Debug.Log(score);
    }
}