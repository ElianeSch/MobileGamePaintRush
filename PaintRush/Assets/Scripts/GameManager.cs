using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;
    //public GameObject tuto;
    public string currentLevel;
    public int difficulty;
    public List<int> difficultyUnlocked = new List<int>();
    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de GManager dans la scène !");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadAndSaveData.instance.LoadFromJson();
        difficultyUnlocked = LoadAndSaveData.instance.unlocked.difficultyUnlocked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            //tuto.SetActive(false);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void LoadNext()
    {
        if(difficulty<2)
        {
            difficulty = difficulty+1;
        }
        SceneManager.LoadScene("MainScene");
    }

}
