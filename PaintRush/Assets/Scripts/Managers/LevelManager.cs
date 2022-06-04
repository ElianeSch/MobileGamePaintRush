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

    public Image levelPreviewImage;
    public Sprite lockedSprite;
    public Sprite questionSprite;

    public static LevelManager instance;

    public GameObject panelUnlockNotEnoughStars;

    public ParticleSystem unlockParticles;


    public GameObject panelSkin;
    public GameObject skinBrushPanel;

   /* public TextMeshProUGUI titreSkin;
    public TextMeshProUGUI descriptionSkin;
    public Image imageSkin;*/

    public GameObject panelItemPrefab;

    public TextMeshProUGUI totalNumberOfStarsText;

    private void Start()
    {
        instance = this;


        List<int> difficultyUnlocked = GameManager.instance.difficultyUnlocked;
        int starsToUnlockLevel = GameManager.instance.starsToUnlockLevel;
        int totalStarCount = GameManager.instance.totalStarCount;
        GameManager.instance.SetAndSaveStarCount(totalStarCount);


        if (difficultyUnlocked.Count == 0) // First time we start the game, no info saved
        {
            starsToUnlockLevel = 2;
            totalStarCount = 0;
            LoadAndSaveData.instance.star.starsToUnlockLevel = starsToUnlockLevel;
            LoadAndSaveData.instance.star.totalStarCount = totalStarCount;
            GameManager.instance.SetAndSaveStarCount(totalStarCount);
            difficultyUnlocked = new List<int>();
            foreach (PaintingSO painting in PaintingsLibrary.instance.paintingsList)
            {
                difficultyUnlocked.Add(0);
            }

            difficultyUnlocked[2] = -1;
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

        totalNumberOfStarsText.text = GameManager.instance.GetStarsCount().ToString();

        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            GameObject newPanelItem = Instantiate(panelItemPrefab, skinBrushPanel.transform);

            newPanelItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.instance.items[i].title;
            newPanelItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.instance.items[i].description;
            newPanelItem.GetComponentInChildren<Image>().sprite = GameManager.instance.items[i].sprite;

        }


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


    public void UpdateStarsToUnlockLevels()
    {
        for (int i = 0; i < PaintingsLibrary.instance.paintingsList.Count; i++)
        {
            GameObject level = panel.transform.GetChild(i).gameObject;
            if (level.GetComponent<IndividualLevel>().locked)
            {
                level.GetComponent<IndividualLevel>().starsToUnlockThisLevel = GameManager.instance.starsToUnlockLevel;
                level.GetComponent<IndividualLevel>().ChangeNumberOfStarsToUnlockLevel();
            }

        }
    }

    public void OpenSkinPanel()
    {
      /*  for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            GameObject newPanelItem = Instantiate(panelItemPrefab, skinBrushPanel.transform);

            newPanelItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.instance.items[i].title;
            newPanelItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.instance.items[i].description;
            newPanelItem.GetComponentInChildren<Image>().sprite = GameManager.instance.items[i].sprite;

        }*/


        panelSkin.SetActive(true);
    }

    public void CloseSkinPanel()
    {
        panelSkin.SetActive(false);
    }


}
