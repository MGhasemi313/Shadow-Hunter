using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}