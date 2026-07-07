using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 checkpointPosition;
    public static GameManager Instance;
    public int score;
    public int coins;
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

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
    }

    public Vector3 GetCheckpoint()
    {
        return checkpointPosition;
    }
    public void AddScore(int value)
    {
        score += value;
        UIManager.Instance.UpdateScore(score);
        Debug.Log(score);
    }
    public void AddCoin(int value)
    {
        coins += value;

        AddScore(10);

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateCoin(coins);
    }
}