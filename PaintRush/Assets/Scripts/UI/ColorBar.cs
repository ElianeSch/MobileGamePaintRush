using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorBar : MonoBehaviour
{

    public List<Image> listZones = new List<Image>();
    public Image arrow;
    public Image rainbow;
    public int mask;
    public int currentZone;
    private RectTransform arrowRectTransform;
    private RectTransform rainbowRectTransform;
    public float offset;
    public int colorBarColorKey;


    private void Awake()
    {
        arrowRectTransform = arrow.GetComponent<RectTransform>();
        rainbowRectTransform = rainbow.GetComponent<RectTransform>();
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
        UpdateRainbow(MainManager.instance.paintingManager.GetPixelColor(MainManager.instance.paintingManager.pixelTarget));

    }


    public void UpdateArrow()
    {
        Vector2 newPos = new Vector2(listZones[currentZone].rectTransform.anchoredPosition.x, listZones[currentZone].rectTransform.anchoredPosition.y + offset);
        arrowRectTransform.anchoredPosition = newPos;
    }

    public void UpdateRainbow(Color targetColor)
    {
        rainbow.enabled = false;
        for (int i = 0; i < 4; i++)
        {
            if(targetColor == listZones[i].color)
            {
                rainbow.enabled = true;
                Vector2 newPos = new Vector2(listZones[i].rectTransform.anchoredPosition.x, listZones[i].rectTransform.anchoredPosition.y);
                rainbowRectTransform.anchoredPosition = newPos;
            }
            
        }
    }



}
