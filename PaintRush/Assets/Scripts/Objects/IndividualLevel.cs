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

            // Si on a déjà débloqué le niveau
            // On enlève l'image du cadenas
            // On peut appuyer sur le bouton pour lancer le niveau
            transform.Find("Lock").gameObject.SetActive(false);
            button.interactable = true;

            // On désactive le panel unlock
            GameObject unlockPanel = transform.Find("UnlockPanel").gameObject;
            unlockPanel.SetActive(false);

            // Et on affiche aussi le nombre d'étoiles
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
                print(stars);
                LevelManager.instance.listButtons[i].interactable = true;
            }
            else
            {
                LevelManager.instance.listButtons[i].interactable = false;
            }
                 
        }
        LevelManager.instance.panelPreview.SetActive(true);
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
            SetLevel();
        }
    }

}