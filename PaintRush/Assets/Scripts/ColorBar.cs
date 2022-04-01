using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorBar : MonoBehaviour
{

    public List<Image> listZones = new List<Image>();
    public int mask;
    public int currentZone;


    private void Start()
    {
     
    }

    public void UpdateColorBar(int currentColorKey)
    {
        int colorBarColorKey= (85 & mask);
        int currentColorMinusColorBar = (currentColorKey & (~mask));
        for(int i = 0; i<4; i++)
        {
            int zoneKey = currentColorMinusColorBar + i * colorBarColorKey;
            if(currentColorKey == zoneKey)
            {
                currentZone = i;
            }
            listZones[i].color = MainManager.instance.GetColorFromKey(zoneKey);
        }

    }




}
