using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour

{
    public List<ColorBar> listColorBar = new List<ColorBar>();
    public int indexSelectedColorBar = 0;

    public Image targetImage;


    public TextMeshProUGUI textGoldCount;


    public GameObject[] life;
    public Image backgroundImage;


    void Start()
    {
        if (GameManager.instance.backgroundIsColored == true)
        {
            Camera.main.backgroundColor = GameManager.instance.colorBackground;
            backgroundImage.enabled = false;
        }
        else
        {
            backgroundImage.enabled = true;
            backgroundImage.sprite = GameManager.instance.allBackground[LoadAndSaveData.instance.unlockedItems.currentBackgroundIndex].spriteBackground;
        }


    }

    public void UpdateColorBars(int currentColorKey)
    {
        foreach(ColorBar colorbar in listColorBar)
        {
            colorbar.UpdateColorBar(currentColorKey);
        }
    }


    public void SelectColorBar(int index)
    {
        indexSelectedColorBar = index;
        UpdateSizeColorBar();
    }


    public void UpdateSizeColorBar()
    {
        for (int i=0;i<4;i++)
        {
            if (i == indexSelectedColorBar)
            {
                listColorBar[i].transform.parent.gameObject.GetComponent<RectTransform>().localScale = new Vector2(1.7f, 1.6f);
            }

            else
            {
                listColorBar[i].transform.parent.gameObject.GetComponent<RectTransform>().localScale = new Vector2(1.5f, 1.5f);
            }
        }
    }

    public void UpdateTargetImage(Color targetColor)
    {
        Color color = new Color(targetColor.r, targetColor.g, targetColor.b, 1f);
        targetImage.color = color;
    }


    public void UpdateGoldCount(int goldCount)
    {
        textGoldCount.text = goldCount.ToString();
    }


    public void CreateLifeCount(int maxLife)
    {
        for (int i = 0; i< maxLife; i++)
        {
            life[i].SetActive(true);
        }
    }

    public void UpdateLifeCount(int lifeRemaining)
    {
        life[lifeRemaining].SetActive(false);
    }

    public void SetBackground(BackgroundSO background)
    {
        backgroundImage.sprite = background.spriteBackground;
    }

}
