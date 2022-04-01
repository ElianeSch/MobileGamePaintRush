using UnityEngine;
using System.Collections.Generic;

public class CanvasManager : MonoBehaviour
{
    public List<ColorBar> listColorBar = new List<ColorBar>();

 
    public void UpdateColorBars(int currentColorKey)
    {
        foreach(ColorBar colorbar in listColorBar)
        {
            colorbar.UpdateColorBar(currentColorKey);
        }
    }



}
