using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI numberStars;
    public TextMeshProUGUI numberPaintings;
    public TextMeshProUGUI numberCoins;
    public TextMeshProUGUI numberSkins;



    private void Start()
    {
        UpdateTextMenus();
    }
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

    public void LoadSkin()
    {
        SceneManager.LoadScene("Personnalisation");
    }

    public void UpdateTextMenus()
    {
        numberStars.text = GameManager.instance.GetStarsCount().ToString();
        numberCoins.text = GameManager.instance.GetCoinCount().ToString();
        numberPaintings.text = GameManager.instance.GetFinishedPaintingsCount().ToString();
        numberSkins.text = GameManager.instance.GetUnlockedSkinsCount().ToString();
    }

}
