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

    public void SetLevel()

    {
        Button button = transform.GetComponentInChildren<Button>();
        button.transform.GetComponentInChildren<TextMeshProUGUI>().text = (levelIndex+1).ToString();

        if (locked)
        {
            transform.Find("Lock").gameObject.SetActive(true);
            button.interactable = false;

        }
        else
        {
            transform.Find("Lock").gameObject.SetActive(false);
            button.interactable = true;
        }

        GameObject starPanel = transform.Find("StarsPanel").gameObject;
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
}