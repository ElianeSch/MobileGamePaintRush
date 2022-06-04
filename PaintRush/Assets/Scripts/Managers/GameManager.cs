using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;
    //public GameObject tuto;
    public int indexLevel;
    public int difficulty;
    public int indexDoor;


    public List<int> difficultyUnlocked = new List<int>();
    public GameObject pausePanel;
    public int totalGold;

    public int totalStarCount;
    public int starsToUnlockLevel;

    public int numberLevelUnlocked;

    public List<PinceauSO> items = new List<PinceauSO>();
    public PinceauSO currentBrush;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de GameManager dans la scène !");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadData();

        print("ici !");

        SetAndSaveStarsToUnlockLevel();

    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        LoadAndSaveData.instance.SaveToJson();
        LoadData();
      

    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void LoadGalleryDoors()
    {
        SceneManager.LoadScene("GalleryDoors");
    }

    public void LoadGallery(int index)
    {
        indexDoor = index;
        SceneManager.LoadScene("Gallery");
    }

    public void LoadNext()
    {
        if(difficulty<2)
        {
            difficulty = difficulty+1;
            LoadAndSaveData.instance.SaveToJson();
            LoadData();
            SceneManager.LoadScene("MainScene");

        }

    }

    public void LoadData()
    {
        LoadAndSaveData.instance.LoadFromJson();
        difficultyUnlocked = LoadAndSaveData.instance.unlocked.difficultyUnlocked;
        totalGold = LoadAndSaveData.instance.gold.totalGoldCount;
        totalStarCount = LoadAndSaveData.instance.star.totalStarCount;
        starsToUnlockLevel = LoadAndSaveData.instance.star.starsToUnlockLevel;
        items = LoadAndSaveData.instance.unlockedItems.items;
        currentBrush = LoadAndSaveData.instance.unlockedItems.currentBrush;

    }

    public int GetCoinCount()
    {
        LoadData();
        return totalGold;
    }


    public int GetStarsCount()
    {
        LoadData();
        return totalStarCount;
    }

    public void SetandSaveCoinCount(int newGold)
    {
        totalGold = newGold;
        LoadAndSaveData.instance.gold.totalGoldCount = totalGold;
        LoadAndSaveData.instance.SaveToJson();
    }

    public void SetAndSaveStarCount(int starCount)
    {
        totalStarCount = starCount;
        LoadAndSaveData.instance.star.totalStarCount = totalStarCount;
        LoadAndSaveData.instance.SaveToJson();
    }
    
    public void SetAndSaveStarsToUnlockLevel()
    {
        numberLevelUnlocked = 0;

        for (int i = 0; i < difficultyUnlocked.Count; i++)
        {
            if (difficultyUnlocked[i] != -1)
                numberLevelUnlocked += 1;
        }

        starsToUnlockLevel = numberLevelUnlocked * 2;
        LoadAndSaveData.instance.star.starsToUnlockLevel = starsToUnlockLevel;
        LoadAndSaveData.instance.SaveToJson();
       
    }

    public void AddUnlockedItemAndSave(PinceauSO item)
    {
        LoadAndSaveData.instance.unlockedItems.items.Add(item);
        LoadAndSaveData.instance.SaveToJson();
    }


    public void SetAndSaveCurentBrush(PinceauSO brush)
    {
        LoadAndSaveData.instance.unlockedItems.currentBrush = brush;
        LoadAndSaveData.instance.SaveToJson();
    }

}
