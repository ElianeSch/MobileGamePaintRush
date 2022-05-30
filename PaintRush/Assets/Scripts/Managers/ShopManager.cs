using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{

    public int coins;

    public TextMeshProUGUI coinUI;

    public ShopItemSO[] shopItemsSOTab1;
    public ShopItemSO[] shopItemsSOTab2;
    public ShopItemSO[] shopItemsSOTab3;

    public ShopTemplate[] shopPanelsTab1;
    public ShopTemplate[] shopPanelsTab2;
    public ShopTemplate[] shopPanelsTab3;

    public GameObject[] shopPanelsGOTab1;
    public GameObject[] shopPanelsGOTab2;
    public GameObject[] shopPanelsGOTab3;



    private void Start()
    {

        for (int i = 0; i < shopItemsSOTab1.Length; i++)
        {
            shopPanelsGOTab1[i].SetActive(true);
        }
        for (int i = 0; i < shopItemsSOTab2.Length; i++)
        {
            shopPanelsGOTab2[i].SetActive(true);
        }
        for (int i = 0; i < shopItemsSOTab3.Length; i++)
        {
            shopPanelsGOTab3[i].SetActive(true);
        }
        coins = 10;
        coinUI.text = "x " + coins.ToString();
        LoadPanels();
    }





    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSOTab1.Length; i++)
        {
            shopPanelsTab1[i].titleTxt.text = shopItemsSOTab1[i].title;
            shopPanelsTab1[i].descriptionTxt.text = shopItemsSOTab1[i].description;
            shopPanelsTab1[i].image.sprite = shopItemsSOTab1[i].sprite;
            shopPanelsTab1[i].costTxt.text = "Coins : " + shopItemsSOTab1[i].cost.ToString();
        }
        for (int i = 0; i < shopItemsSOTab2.Length; i++)
        {
            shopPanelsTab2[i].titleTxt.text = shopItemsSOTab2[i].title;
            shopPanelsTab2[i].descriptionTxt.text = shopItemsSOTab2[i].description;
            shopPanelsTab2[i].image.sprite = shopItemsSOTab2[i].sprite;
            shopPanelsTab2[i].costTxt.text = "Coins : " + shopItemsSOTab2[i].cost.ToString();
        }
        for (int i = 0; i < shopItemsSOTab3.Length; i++)
        {
            shopPanelsTab3[i].titleTxt.text = shopItemsSOTab3[i].title;
            shopPanelsTab3[i].descriptionTxt.text = shopItemsSOTab3[i].description;
            shopPanelsTab3[i].image.sprite = shopItemsSOTab3[i].sprite;
            shopPanelsTab3[i].costTxt.text = "Coins : " + shopItemsSOTab3[i].cost.ToString();
        }
    }


}
