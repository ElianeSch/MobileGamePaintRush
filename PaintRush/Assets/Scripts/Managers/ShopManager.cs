using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


[Serializable]
public class ShopItemTabsList
{
    public ShopItemSO[] shopItemSOTab;
}

[Serializable]
public class GameObjectTabsList
{
    public GameObject[] shopPanelGOTab;
}

[Serializable]
public class ShopTemplateTabsList
{
    public ShopTemplate[] shopPanelTab;
}



public class ShopManager : MonoBehaviour
{

    public int coins;
    public TextMeshProUGUI coinUI;

    public List<GameObject> listTabs;

    int numberTabs;

    public ShopItemTabsList[] shopItemSOTabsList;
    public GameObjectTabsList[] shopPanelGOTabsList;
    public ShopTemplateTabsList[] shopPanelTabsList;

    //private List<List<Button>> purchaseButtonsList = new List<List<Button>>();



    void Awake()
    {
        numberTabs = listTabs.Count;

        for (int i = 0; i < numberTabs; i++)
        {
            //purchaseButtonsList.Add(new List<Button>());
            for (int j = 0; j < shopPanelGOTabsList[i].shopPanelGOTab.Length; j++)
            {
                shopPanelGOTabsList[i].shopPanelGOTab[j].SetActive(false);
                Button button = shopPanelGOTabsList[i].shopPanelGOTab[j].GetComponentInChildren<Button>();
                AddButtonListener(button,i,j);
                //purchaseButtonsList[i].Add(button);
               
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < numberTabs; i++)
        {
            for (int j = 0; j < shopItemSOTabsList[i].shopItemSOTab.Length; j++)
            {
                shopPanelGOTabsList[i].shopPanelGOTab[j].SetActive(true);
            }
        }

        coins = GameManager.instance.GetCoinCount();
        coinUI.text = "x " + coins.ToString();

        LoadPanels();

    }


    public void LoadPanels()
    {
        for (int i = 0; i < numberTabs; i++)
        {
            for (int j = 0; j < shopItemSOTabsList[i].shopItemSOTab.Length; j++)
            {
                shopPanelTabsList[i].shopPanelTab[j].titleTxt.text = shopItemSOTabsList[i].shopItemSOTab[j].title;
                shopPanelTabsList[i].shopPanelTab[j].descriptionTxt.text = shopItemSOTabsList[i].shopItemSOTab[j].description;
                shopPanelTabsList[i].shopPanelTab[j].image.sprite = shopItemSOTabsList[i].shopItemSOTab[j].sprite;
                shopPanelTabsList[i].shopPanelTab[j].costTxt.text = "Coins : " + shopItemSOTabsList[i].shopItemSOTab[j].cost.ToString();
            }
        }
    }


    public void PurchaseItem(int indexButton_i, int indexButton_j)
    {
        ShopItemSO itemToBuy = shopItemSOTabsList[indexButton_i].shopItemSOTab[indexButton_j];
       if (coins >= itemToBuy.cost)
        {
            coins = coins - itemToBuy.cost;
            coinUI.text = "Coins : " + coins.ToString();
            GameManager.instance.SetandSaveCoinCount(coins);

            // Check which type is the item

            if (itemToBuy is PinceauSO)
            {
                GameManager.instance.AddUnlockedBrushAndSave(itemToBuy as PinceauSO);
            }

            else if (itemToBuy is BackgroundSO)
            {
                GameManager.instance.AddUnlockedBackgroundAndSave(itemToBuy as BackgroundSO);
            }


        }
    }

    void AddButtonListener(Button b, int index_i, int index_j)
    {
        b.onClick.AddListener(() => { PurchaseItem(index_i, index_j); });
    }


}
