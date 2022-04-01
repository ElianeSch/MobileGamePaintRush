using UnityEngine;
using System.Collections.Generic;

public class CanvasManager : MonoBehaviour
{
    public List<ColorBar> listColorBar = new List<ColorBar>();
    public int indexSelectedColorBar=0;
 
    public void UpdateColorBars(int currentColorKey)
    {
        foreach(ColorBar colorbar in listColorBar)
        {
            colorbar.UpdateColorBar(currentColorKey);
        }
    }


    public void SelectColorBar(int index)
    {
        print(index);
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
}
