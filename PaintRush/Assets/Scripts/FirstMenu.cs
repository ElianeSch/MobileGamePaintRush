using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
