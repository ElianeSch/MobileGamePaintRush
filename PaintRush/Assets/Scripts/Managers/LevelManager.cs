using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{


    //public GameObject prefabCategoryPanel;
    public IndividualLevel individualLevel;
    public GameObject panel;
    public List<GameObject> listCategoryPanels;
    public int numberCategories;
    public GameObject panelPreview;
    public List<Button> listButtons;
    public static LevelManager instance;


    public GameObject panelUnlockConfirmation;
    public GameObject panelUnlockNotEnoughStars;

    private void Start()
    {
        instance = this;
        List<int> difficultyUnlocked = GameManager.instance.difficultyUnlocked;
        if (difficultyUnlocked.Count == 0) // First time we start the game, no info saved
        {
            difficultyUnlocked = new List<int>();
            foreach (PaintingSO painting in PaintingsLibrary.instance.paintingsList)
            {
                difficultyUnlocked.Add(0);
            }
            LoadAndSaveData.instance.unlocked.difficultyUnlocked = difficultyUnlocked;
            LoadAndSaveData.instance.SaveToJson();

            GameManager.instance.LoadData();
        }


        for (int i =0; i<PaintingsLibrary.instance.paintingsList.Count; i++)
        {
            IndividualLevel newLevel = Instantiate(individualLevel, panel.transform);
            int difficulty = GameManager.instance.difficultyUnlocked[i];
            if (difficulty == -1)
            {
                newLevel.locked = true;
                newLevel.stars = 0;
                newLevel.starsToUnlockThisLevel = GameManager.instance.starsToUnlockLevel;
            }
            else
            {
                newLevel.locked = false;
                newLevel.stars = difficulty;
            }
            
            newLevel.levelIndex = i;
            newLevel.SetLevel();
        }

        panelUnlockNotEnoughStars.SetActive(false);
        panelUnlockConfirmation.SetActive(false);

    }

    public void LunchLevel(int difficulty)
    {
        GameManager.instance.difficulty = difficulty;
        GameManager.instance.LoadMainScene();
    }


    public void ClosePanelPreview()
    {
        panelPreview.SetActive(false);
    }
}
