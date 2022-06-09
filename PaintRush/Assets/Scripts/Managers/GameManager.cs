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

    public List<PinceauSO> allBrush = new List<PinceauSO>();
    public List<int> unlockedBrushIndex = new List<int>();
    public int currentBrushIndex = -1;

    public List<BackgroundSO> allBackground = new List<BackgroundSO>();
    public List<int> unlockedBackgroundIndex = new List<int>();

    public int currentBackgroundIndex=-1;


    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de GameManager dans la sc�ne !");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadData();
        SetAndSaveStarsToUnlockLevel();
        if (currentBackgroundIndex == -1)
        {
            currentBackgroundIndex = 0;
        }

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

        unlockedBrushIndex = LoadAndSaveData.instance.unlockedItems.unlockedBrushIndex;
        currentBrushIndex = LoadAndSaveData.instance.unlockedItems.currentBrushIndex;

        unlockedBackgroundIndex = LoadAndSaveData.instance.unlockedItems.unlockedBackgroundIndex;
        currentBackgroundIndex = LoadAndSaveData.instance.unlockedItems.currentBackgroundIndex;

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

    public void AddUnlockedBrushAndSave(int brushIndex)
    {
        LoadAndSaveData.instance.unlockedItems.unlockedBrushIndex.Add(brushIndex);
        LoadAndSaveData.instance.SaveToJson();
    }

    public void AddUnlockedBackgroundAndSave(int backgroundIndex)
    {
        LoadAndSaveData.instance.unlockedItems.unlockedBackgroundIndex.Add(backgroundIndex);
        LoadAndSaveData.instance.SaveToJson();
    }


    public void SetAndSaveCurentBrush(int brushIndex)
    {
        LoadAndSaveData.instance.unlockedItems.currentBrushIndex = brushIndex;
        LoadAndSaveData.instance.SaveToJson();
    }

    public void SetAndSaveCurrentBackground(int backgroundIndex)
    {
        LoadAndSaveData.instance.unlockedItems.currentBackgroundIndex = backgroundIndex;
        LoadAndSaveData.instance.SaveToJson();
    }

    public int GetBackgroundIndex(BackgroundSO background)
    {
        int backgroundIndex = allBackground.IndexOf(background);
        return backgroundIndex;
    }

     public int GetBrushIndex(PinceauSO brush)
    {
        int brushIndex = allBrush.IndexOf(brush);
        return brushIndex;
    }

}
