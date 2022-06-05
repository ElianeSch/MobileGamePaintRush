using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{

    public GameObject panelSkin;
    public GameObject skinBrushPanel;

    public PinceauSO itemBrush;

    public GameObject panelItemPrefab;

    private List<Button> listEquipButtons = new List<Button>();

    private void Start()
    {
        if (GameManager.instance.difficultyUnlocked.Count == 0)
        {
            GameManager.instance.SetAndSaveCurentBrush(itemBrush);
        }
        LoadAndSaveData.instance.SaveToJson();

        GameManager.instance.LoadData();



        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            GameObject newPanelItem = Instantiate(panelItemPrefab, skinBrushPanel.transform);

            newPanelItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.instance.items[i].title;
            newPanelItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.instance.items[i].description;
            newPanelItem.GetComponentInChildren<Image>().sprite = GameManager.instance.items[i].sprite;

            Button button = newPanelItem.GetComponentInChildren<Button>();
            AddButtonListener(button, i);
            listEquipButtons.Add(button);

        }


    }

    public void OpenSkinPanel()
    {

        panelSkin.SetActive(true);
    }

    public void CloseSkinPanel()
    {
        panelSkin.SetActive(false);
    }


    public void EquipBrush(int indexSkinPanel)
    {
        GameManager.instance.SetAndSaveCurentBrush(GameManager.instance.items[indexSkinPanel]);
    }


    void AddButtonListener(Button b, int index)
    {
        b.onClick.AddListener(() => { EquipBrush(index); });
    }



}
