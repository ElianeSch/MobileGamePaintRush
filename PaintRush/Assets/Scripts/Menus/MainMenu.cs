using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ReturnToFirstMenu()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        SceneManager.MoveGameObjectToScene(GameManager, SceneManager.GetActiveScene());
        SceneManager.LoadScene("FirstMenu");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
