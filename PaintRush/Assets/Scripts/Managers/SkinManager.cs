using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{

    public GameObject panelSkin;
    public GameObject skinBrushPanel;

    public GameObject skinBackgroundPanel;

    public PinceauSO itemBrush;
    public BackgroundSO defaultBackground;

    public GameObject panelItemPrefab;

    //private List<Button> listEquipButtons = new List<Button>();




    private void Awake()
    {

        if (GameManager.instance.difficultyUnlocked.Count == 0)
        {
            GameManager.instance.SetAndSaveCurentBrush(itemBrush);
            GameManager.instance.SetAndSaveCurrentBackground(defaultBackground);
        }
        LoadAndSaveData.instance.SaveToJson();

        GameManager.instance.LoadData();





        // Brush
        for (int i = 0; i < GameManager.instance.unlockedBrush.Count; i++)
        {
            print("bonjour");
            GameObject newPanelItem = Instantiate(panelItemPrefab, skinBrushPanel.transform);
            newPanelItem.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.instance.unlockedBrush[i].sprite;
            newPanelItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.instance.unlockedBrush[i].title;
            newPanelItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.instance.unlockedBrush[i].description;


            Button button = newPanelItem.GetComponentInChildren<Button>();
            AddButtonListenerBrush(button, i);
            //listEquipButtons.Add(button);

        }

        // Background

        for (int i = 0; i < GameManager.instance.unlockedBackground.Count; i++)
        {
            print(i);
            GameObject newPanelItem = Instantiate(panelItemPrefab, skinBackgroundPanel.transform);
            newPanelItem.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.instance.unlockedBackground[i].sprite;
            newPanelItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.instance.unlockedBackground[i].title;
            newPanelItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.instance.unlockedBackground[i].description;

            Button button = newPanelItem.GetComponentInChildren<Button>();
            AddButtonListenerBackground(button, i);
            //listEquipButtons.Add(button);
        }

    }


    public void EquipBrush(int index)
    {
        GameManager.instance.SetAndSaveCurentBrush(GameManager.instance.unlockedBrush[index]);
    }
    
    public void EquipBackground(int index)
    {
        GameManager.instance.SetAndSaveCurrentBackground(GameManager.instance.unlockedBackground[index]);
    }

    void AddButtonListenerBrush(Button b, int index)
    {
        b.onClick.AddListener(() => { EquipBrush(index); });
    }

    void AddButtonListenerBackground(Button b, int index)
    {
        b.onClick.AddListener(() => { EquipBackground(index); });
    }

}
