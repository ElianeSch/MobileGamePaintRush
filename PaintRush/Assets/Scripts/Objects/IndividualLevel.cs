using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class IndividualLevel : MonoBehaviour
{
    public bool locked;
    public int stars;
    public int levelIndex;
    public int categoryIndex;
    public Sprite starVoid;
    public Sprite starCompleted;
    public int starsToUnlockThisLevel;
    public GameObject starPanel;


    public void SetLevel()

    {
        Button button = transform.GetComponentInChildren<Button>();
        button.transform.GetComponentInChildren<TextMeshProUGUI>().text = (levelIndex+1).ToString();

        if (locked)
        {
            transform.Find("Lock").gameObject.SetActive(true);
            button.interactable = false;
            starPanel.SetActive(false);

            GameObject unlockPanel = transform.Find("UnlockPanel").gameObject;
            unlockPanel.SetActive(true);
            unlockPanel.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = starsToUnlockThisLevel.ToString();


        }
        else
        {

            // Si on a d?j? d?bloqu? le niveau
            // On enl?ve l'image du cadenas
            // On peut appuyer sur le bouton pour lancer le niveau
            transform.Find("Lock").gameObject.SetActive(false);
            button.interactable = true;

            // On d?sactive le panel unlock
            GameObject unlockPanel = transform.Find("UnlockPanel").gameObject;
            unlockPanel.SetActive(false);

            // Et on affiche aussi le nombre d'?toiles
            starPanel.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                if (i < stars)
                {
                    starPanel.transform.GetChild(i).GetComponent<Image>().sprite = starCompleted;
                }
                else
                {
                    starPanel.transform.GetChild(i).GetComponent<Image>().sprite = starVoid;
                }
            }
        }
    }

    public void ClickOnLevel()
    {
        GameManager.instance.indexLevel = levelIndex;

        for (int i = 0; i < 3; i++)
        {
            if (i <= stars)
            {
                LevelManager.instance.listButtons[i].interactable = true;
            }
            else
            {
                LevelManager.instance.listButtons[i].interactable = false;
            }
                 
        }
        LevelManager.instance.panelPreview.SetActive(true);

        if (this.locked == true)
        {
            LevelManager.instance.levelPreviewImage.sprite = LevelManager.instance.lockedSprite;
        }

        else if (stars == 0)
        {
            LevelManager.instance.levelPreviewImage.sprite = LevelManager.instance.questionSprite;
        }
        else
        {
            LevelManager.instance.levelPreviewImage.sprite = PaintingsLibrary.instance.paintingsList[levelIndex].spritesPainting[stars - 1];
        }



       

    }


    public void UnlockLevel()
    {
        if (starsToUnlockThisLevel > GameManager.instance.totalStarCount)
        {
            LevelManager.instance.panelUnlockNotEnoughStars.SetActive(true);
        }

        else
        {
            locked = false;
            LoadAndSaveData.instance.unlocked.difficultyUnlocked[levelIndex] = 0;
            LoadAndSaveData.instance.SaveToJson();
            GameManager.instance.SetAndSaveStarsToUnlockLevel();
            SetLevel();
            LevelManager.instance.UpdateStarsToUnlockLevels();
            //Destroy(Instantiate(LevelManager.instance.unlockParticles, gameObject.transform, Quaternion.identity), 2f);
            Destroy(Instantiate(LevelManager.instance.unlockParticles, gameObject.transform),2);
        }
    }

    public void ChangeNumberOfStarsToUnlockLevel()
    {

        GameObject unlockPanel = transform.Find("UnlockPanel").gameObject;
        unlockPanel.SetActive(true);
        unlockPanel.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = starsToUnlockThisLevel.ToString();
    }
}