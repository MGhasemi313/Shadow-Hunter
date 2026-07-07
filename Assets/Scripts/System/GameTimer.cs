using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float startTime = 120f; // 2 دقیقه
    [SerializeField] private TextMeshProUGUI timerText;

    private float currentTime;
    private bool isRunning = true;

    private void Start()
    {
        currentTime = startTime;
        UpdateTimerUI();
    }

    private void Update()
    {
        if (!isRunning)
            return;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            currentTime = 0;
            isRunning = false;

            TimerFinished();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format(
            "{0:00}:{1:00}",
            minutes,
            seconds
        );
    }

    private void TimerFinished()
    {
        Debug.Log("Time Over");

        SceneManager.LoadScene("GameOver");
    }
}