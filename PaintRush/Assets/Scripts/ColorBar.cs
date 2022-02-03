using UnityEngine;
using UnityEngine.UI;

public class ColorBar : MonoBehaviour
{

    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public Image fill2;
    public Image fill3;
    public Image fill4;

    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    public void SetBlankBar()
    {
        slider.maxValue = 3;
        slider.value = 3;
        colorKey = new GradientColorKey[3];

        colorKey[0].color = new Color(1.0f,1.0f,1.0f);
        colorKey[0].time = 0.33f;

        colorKey[1].color = new Color(1.0f, 1.0f, 1.0f);
        colorKey[1].time = 0.66f;

        colorKey[2].color = new Color(1.0f, 1.0f, 1.0f);
        colorKey[2].time = 1.0f;

        alphaKey = new GradientAlphaKey[3];

        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.33f;

        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.66f;

        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        fill.color = colorKey[0].color;
        fill2.color = colorKey[1].color;
        fill3.color = colorKey[2].color;
    }

    public void SetSliderGradient(int[] listeIndex)
    {
        colorKey = new GradientColorKey[4];

        colorKey[0].color = new Color(Pinceau.instance.paletteRGB[listeIndex[0], 0], Pinceau.instance.paletteRGB[listeIndex[0], 1], Pinceau.instance.paletteRGB[listeIndex[0],2]);
        colorKey[0].time = 0.25f;

        colorKey[1].color = new Color(Pinceau.instance.paletteRGB[listeIndex[1], 0], Pinceau.instance.paletteRGB[listeIndex[1], 1], Pinceau.instance.paletteRGB[listeIndex[1], 2]);
        colorKey[1].time = 0.50f;

        colorKey[2].color = new Color(Pinceau.instance.paletteRGB[listeIndex[2], 0], Pinceau.instance.paletteRGB[listeIndex[2], 1], Pinceau.instance.paletteRGB[listeIndex[2], 2]);
        colorKey[2].time = 0.75f;

        colorKey[3].color = new Color(Pinceau.instance.paletteRGB[listeIndex[3], 0], Pinceau.instance.paletteRGB[listeIndex[3], 1], Pinceau.instance.paletteRGB[listeIndex[3], 2]);
        colorKey[3].time = 1.0f;

        alphaKey = new GradientAlphaKey[4];

        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.25f;

        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.50f;

        alphaKey[2].alpha = 1.0f;
        alphaKey[2].time = 0.75f;


        alphaKey[3].alpha = 1.0f;
        alphaKey[3].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        fill.color = colorKey[0].color;
        fill2.color = colorKey[1].color;
        fill3.color = colorKey[2].color;
        fill4.color = colorKey[3].color;
    }

}
