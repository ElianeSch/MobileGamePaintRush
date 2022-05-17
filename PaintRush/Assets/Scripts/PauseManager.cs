using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pausePanel;

    private void Start()
    {
        print(gameIsPaused);
    }

    public void PauseMenu()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            print("coucou");
            Pause();
        }

    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        print("resume");
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
