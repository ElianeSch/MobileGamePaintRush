using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour

{
    public List<ColorBar> listColorBar = new List<ColorBar>();
    public int indexSelectedColorBar=0;

    public Image targetImage;


    public TextMeshProUGUI textGoldCount;


    public GameObject[] life;


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
                listColorBar[i].GetComponent<RectTransform>().localScale = new Vector2(1.1f, 0.6f);
            }

            else
            {
                listColorBar[i].GetComponent<RectTransform>().localScale = new Vector2(1f, 0.5f);
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


}
