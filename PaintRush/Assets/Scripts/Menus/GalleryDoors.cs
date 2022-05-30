using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryDoors : MonoBehaviour
{
    public void LoadGalllery(int index)
    {
        GameManager.instance.LoadGallery(index);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
