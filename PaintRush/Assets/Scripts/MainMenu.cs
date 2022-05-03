
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        GameManager.instance.LoadSelectLevel();
    }

    public void Gallery()
    {
        GameManager.instance.LoadGalleryDoors();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
