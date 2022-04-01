using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorBar : MonoBehaviour
{

    public List<Image> listZones = new List<Image>();
    public Image arrow;
    public int mask;
    public int currentZone;
    private RectTransform rectTransform;
    public float offset;
    public int colorBarColorKey;


    private void Awake()
    {
        rectTransform = arrow.GetComponent<RectTransform>();
        offset = listZones[0].GetComponent<RectTransform>().rect.height / 2;
        colorBarColorKey = (85 & mask);

    }

    public void UpdateColorBar(int currentColorKey)
    {
        
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

        UpdateArrow();

    }


    public void UpdateArrow()
    {
        Vector2 newPos = new Vector2(listZones[currentZone].rectTransform.anchoredPosition.x, listZones[currentZone].rectTransform.anchoredPosition.y + offset);
        rectTransform.anchoredPosition = newPos;
    }


}
 