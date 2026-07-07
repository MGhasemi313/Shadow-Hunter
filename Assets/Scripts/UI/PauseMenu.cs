using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }


    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void Settings()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Settings");
    }


    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}