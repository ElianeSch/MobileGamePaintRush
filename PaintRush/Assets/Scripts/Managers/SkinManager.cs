using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{

    public GameObject skinBrushPanel;

    public GameObject skinBackgroundPanel;

    public GameObject panelItemPrefab;

    public GameObject panelColorBackground;


    private void Awake()
    {
        panelColorBackground.SetActive(false);

        if (GameManager.instance.unlockedBackgroundIndex.Count == 0)
        {
            GameManager.instance.SetAndSaveCurrentBackground(0);
            GameManager.instance.AddUnlockedBackgroundAndSave(0);
        }
        if (GameManager.instance.unlockedBrushIndex.Count == 0)
        {
            GameManager.instance.SetAndSaveCurentBrush(0);
            GameManager.instance.AddUnlockedBrushAndSave(0);
        }
        
        LoadAndSaveData.instance.SaveToJson();

        GameManager.instance.LoadData();





        // Brush
        for (int i = 0; i < GameManager.instance.unlockedBrushIndex.Count; i++)
        {
            print("ok");
            GameObject newPanelItem = Instantiate(panelItemPrefab, skinBrushPanel.transform);
            PinceauSO brush = GameManager.instance.allBrush[GameManager.instance.unlockedBrushIndex[i]];
            newPanelItem.transform.GetChild(0).GetComponent<Image>().sprite = brush.sprite;
            newPanelItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = brush.title;
            newPanelItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = brush.description;


            Button button = newPanelItem.GetComponentInChildren<Button>();
            AddButtonListenerBrush(button, i);
            //listEquipButtons.Add(button);

        }
        // Background

        for (int i = 0; i < GameManager.instance.unlockedBackgroundIndex.Count; i++)
        {
            GameObject newPanelItem = Instantiate(panelItemPrefab, skinBackgroundPanel.transform);
            BackgroundSO background =  GameManager.instance.allBackground[GameManager.instance.unlockedBackgroundIndex[i]];
            newPanelItem.transform.GetChild(0).GetComponent<Image>().sprite = background.sprite;
            newPanelItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = background.title;
            newPanelItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = background.description;

            Button button = newPanelItem.GetComponentInChildren<Button>();
            AddButtonListenerBackground(button, i);
            //listEquipButtons.Add(button);
        }

    }


    public void EquipBrush(int index)
    {
        GameManager.instance.SetAndSaveCurentBrush(GameManager.instance.unlockedBrushIndex[index]);
        GameManager.instance.LoadData();
    }
    
    public void EquipBackground(int index)
    {
        GameManager.instance.SetAndSaveCurrentBackground(GameManager.instance.unlockedBackgroundIndex[index]);
        GameManager.instance.LoadData();
    }

    void AddButtonListenerBrush(Button b, int index)
    {
        b.onClick.AddListener(() => { EquipBrush(index); });
    }

    void AddButtonListenerBackground(Button b, int index)
    {
        b.onClick.AddListener(() => { EquipBackground(index); });
    }

    public void ButtonColorBackground(Button button)
    {
        GameManager.instance.SetAndSaveColorBackground(button.GetComponent<Image>().color);
        panelColorBackground.SetActive(false);
    }

    public void OpenColorBackground()
    {
        panelColorBackground.SetActive(true);
    }
}
