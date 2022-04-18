
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        GameManager.instance.LoadSelectLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
