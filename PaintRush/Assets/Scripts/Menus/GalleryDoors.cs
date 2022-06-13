using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryDoors : MonoBehaviour
{
    public void LoadGalllery(string movement)
    {
        GameManager.instance.LoadGallery(movement);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
