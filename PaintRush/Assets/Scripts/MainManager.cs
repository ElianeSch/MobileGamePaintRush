using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainManager : MonoBehaviour
{


    public static MainManager instance;

    public Brush brush;
    public Canvas canvas;
    public PaintingManager paintingManager;
    public CanvasManager canvasManager;



    public float[,] paletteRGB = new float[,] { { 255.0000f, 255.0000f, 255.0000f}, { 170.8500f, 170.8500f, 170.8500f }, { 86.7000f, 86.7000f, 86.7000f }, { 0, 0, 0 }, { 255.0000f, 255.0000f, 170.8500f }, { 170.8500f, 170.8500f, 114.4695f},
    {86.7000f, 86.7000f, 58.0890f}, {0, 0, 0}, {255.0000f, 255.0000f, 86.7000f}, {170.8500f, 170.8500f, 58.0890f}, {86.7000f, 86.7000f, 29.4780f}, {0, 0, 0}, {255.0000f, 255.0000f, 0}, {170.8500f, 170.8500f, 0}, {86.7000f, 86.7000f, 0}, {0, 0, 0}, {255.0000f, 170.8500f, 255.0000f},
    {170.8500f, 114.4695f, 170.8500f}, {86.7000f, 58.0890f, 86.7000f}, {0, 0, 0}, {255.0000f, 170.8500f, 170.8500f}, {170.8500f, 114.4695f, 114.4695f}, {86.7000f, 58.0890f, 58.0890f}, {0, 0, 0}, {255.0000f, 170.8500f, 86.7000f}, {170.8500f, 114.4695f, 58.0890f},
    {86.7000f, 58.0890f, 29.4780f}, {0, 0, 0}, {255.0000f, 170.8500f, 0}, {170.8500f, 114.4695f, 0}, {86.7000f, 58.0890f, 0}, {0, 0, 0}, {255.0000f, 86.7000f, 255.0000f}, {170.8500f, 58.0890f, 170.8500f}, {86.7000f, 29.4780f, 86.7000f}, {0, 0, 0},
    {255.0000f, 86.7000f, 170.8500f}, {170.8500f, 58.0890f, 114.4695f}, {86.7000f, 29.4780f, 58.0890f}, {0, 0, 0}, {255.0000f, 86.7000f, 86.7000f}, {170.8500f, 58.0890f, 58.0890f}, {86.7000f, 29.4780f, 29.4780f}, {0, 0, 0}, {255.0000f, 86.7000f, 0},
    {170.8500f, 58.0890f, 0}, {86.7000f, 29.4780f, 0}, {0, 0, 0}, {255.0000f, 0, 255.0000f}, {170.8500f, 0, 170.8500f}, {86.7000f, 0, 86.7000f}, {0, 0, 0}, {255.0000f, 0, 170.8500f}, {170.8500f, 0, 114.4695f}, {86.7000f, 0, 58.0890f}, {0, 0, 0},
    {255.0000f, 0, 86.7000f}, {170.8500f, 0, 58.0890f}, {86.7000f, 0, 29.4780f}, {0, 0, 0}, {255.0000f, 0, 0}, {170.8500f, 0, 0}, {86.7000f, 0, 0}, {0, 0, 0}, {170.8500f, 255.0000f, 255.0000f}, {114.4695f, 170.8500f, 170.8500f}, {58.0890f, 86.7000f, 86.7000f},
    {0, 0, 0}, {170.8500f, 255.0000f, 170.8500f}, {114.4695f, 170.8500f, 114.4695f}, {58.0890f, 86.7000f, 58.0890f}, {0, 0, 0}, {170.8500f, 255.0000f, 86.7000f}, {114.4695f, 170.8500f, 58.0890f}, {58.0890f, 86.7000f, 29.4780f}, {0, 0, 0},
    {170.8500f, 255.0000f, 0}, {114.4695f, 170.8500f, 0}, {58.0890f, 86.7000f, 0}, {0, 0, 0}, {170.8500f, 170.8500f, 255.0000f}, {114.4695f, 114.4695f, 170.8500f}, {58.0890f, 58.0890f, 86.7000f}, {0, 0, 0}, {170.8500f, 170.8500f, 170.8500f},
    {114.4695f, 114.4695f, 114.4695f}, {58.0890f, 58.0890f, 58.0890f}, {0, 0, 0}, {170.8500f, 170.8500f, 86.7000f}, {114.4695f, 114.4695f, 58.0890f}, {58.0890f, 58.0890f, 29.4780f}, {0, 0, 0}, {170.8500f, 170.8500f, 0}, {114.4695f, 114.4695f, 0},
    {58.0890f, 58.0890f, 0}, {0, 0, 0}, {170.8500f, 86.7000f, 255.0000f}, {114.4695f, 58.0890f, 170.8500f}, {58.0890f, 29.4780f, 86.7000f}, {0, 0, 0}, {170.8500f, 86.7000f, 170.8500f}, {114.4695f, 58.0890f, 114.4695f}, {58.0890f, 29.4780f, 58.0890f},
    {0, 0, 0}, {170.8500f, 86.7000f, 86.7000f}, {114.4695f, 58.0890f, 58.0890f}, {58.0890f, 29.4780f, 29.4780f}, {0, 0, 0}, {170.8500f, 86.7000f, 0}, {114.4695f, 58.0890f, 0}, {58.0890f, 29.4780f, 0}, {0, 0, 0}, {170.8500f, 0, 255.0000f},
    {114.4695f, 0, 170.8500f}, {58.0890f, 0, 86.7000f}, {0, 0, 0}, {170.8500f, 0, 170.8500f}, {114.4695f, 0, 114.4695f}, {58.0890f, 0, 58.0890f}, {0, 0, 0}, {170.8500f, 0, 86.7000f}, {114.4695f, 0, 58.0890f}, {58.0890f, 0, 29.4780f}, {0, 0, 0},
    {170.8500f, 0, 0}, {114.4695f, 0, 0}, {58.0890f, 0, 0}, {0, 0, 0}, {86.7000f, 255.0000f, 255.0000f}, {58.0890f, 170.8500f, 170.8500f}, {29.4780f, 86.7000f, 86.7000f}, {0, 0, 0}, {86.7000f, 255.0000f, 170.8500f}, {58.0890f, 170.8500f, 114.4695f},
    {29.4780f, 86.7000f, 58.0890f}, {0, 0, 0}, {86.7000f, 255.0000f, 86.7000f}, {58.0890f, 170.8500f, 58.0890f}, {29.4780f, 86.7000f, 29.4780f}, {0, 0, 0}, {86.7000f, 255.0000f, 0}, {58.0890f, 170.8500f, 0}, {29.4780f, 86.7000f, 0},
    {0, 0, 0}, {86.7000f, 170.8500f, 255.0000f}, {58.0890f, 114.4695f, 170.8500f}, {29.4780f, 58.0890f, 86.7000f}, {0, 0, 0}, {86.7000f, 170.8500f, 170.8500f}, {58.0890f, 114.4695f, 114.4695f}, {29.4780f, 58.0890f, 58.0890f},
    {0, 0, 0}, {86.7000f, 170.8500f, 86.7000f}, {58.0890f, 114.4695f, 58.0890f}, {29.4780f, 58.0890f, 29.4780f}, {0, 0, 0}, {86.7000f, 170.8500f, 0}, {58.0890f, 114.4695f, 0}, {29.4780f, 58.0890f, 0}, {0, 0, 0},
    {86.7000f, 86.7000f, 255.0000f}, {58.0890f, 58.0890f, 170.8500f}, {29.4780f, 29.4780f, 86.7000f}, {0, 0, 0}, {86.7000f, 86.7000f, 170.8500f}, {58.0890f, 58.0890f, 114.4695f}, {29.4780f, 29.4780f, 58.0890f}, {0, 0, 0},
    {86.7000f, 86.7000f, 86.7000f}, {58.0890f, 58.0890f, 58.0890f}, {29.4780f, 29.4780f, 29.4780f}, {0, 0, 0}, {86.7000f, 86.7000f, 0}, {58.0890f, 58.0890f, 0}, {29.4780f, 29.4780f, 0}, {0, 0, 0}, {86.7000f, 0, 255.0000f},
    {58.0890f, 0, 170.8500f}, {29.4780f, 0, 86.7000f}, {0, 0, 0}, {86.7000f, 0, 170.8500f}, {58.0890f, 0, 114.4695f}, {29.4780f, 0, 58.0890f}, {0, 0, 0}, {86.7000f, 0, 86.7000f}, {58.0890f, 0, 58.0890f},
    {29.4780f, 0, 29.4780f}, {0, 0, 0}, {86.7000f, 0, 0}, {58.0890f, 0, 0}, {29.4780f, 0, 0}, {0, 0, 0}, {0, 255.0000f, 255.0000f}, {0, 170.8500f, 170.8500f}, {0, 86.7000f, 86.7000f}, {0, 0, 0}, {0, 255.0000f, 170.8500f}, {0, 170.8500f, 114.4695f},
    {0, 86.7000f, 58.0890f}, {0, 0, 0 }, {0, 255.0000f, 86.7000f}, {0, 170.8500f, 58.0890f}, {0, 86.7000f, 29.4780f}, {0, 0, 0}, {0, 255.0000f, 0}, {0, 170.8500f, 0}, {0, 86.7000f, 0}, {0, 0, 0}, {0, 170.8500f, 255.0000f}, {0, 114.4695f, 170.8500f},
    {0, 58.0890f, 86.7000f}, {0, 0, 0}, {0, 170.8500f, 170.8500f}, {0, 114.4695f, 114.4695f}, {0, 58.0890f, 58.0890f}, {0, 0, 0}, {0, 170.8500f, 86.7000f}, {0, 114.4695f, 58.0890f}, {0, 58.0890f, 29.4780f}, {0, 0, 0}, {0, 170.8500f, 0},
    {0, 114.4695f, 0}, {0, 58.0890f, 0}, {0, 0, 0}, {0, 86.7000f, 255.0000f}, {0, 58.0890f, 170.8500f}, {0, 29.4780f, 86.7000f}, {0, 0, 0}, {0, 86.7000f, 170.8500f}, {0, 58.0890f, 114.4695f}, {0, 29.4780f, 58.0890f}, {0, 0, 0}, {0, 86.7000f, 86.7000f},
    {0, 58.0890f, 58.0890f}, {0, 29.4780f, 29.4780f}, {0, 0, 0}, {0, 86.7000f, 0}, {0, 58.0890f, 0}, {0, 29.4780f, 0}, {0, 0, 0}, {0, 0, 255.0000f}, {0, 0, 170.8500f}, {0, 0, 86.7000f}, {0, 0, 0}, {0, 0, 170.8500f}, {0, 0, 114.4695f},
    {0, 0, 58.0890f}, {0, 0, 0}, {0, 0, 86.7000f}, {0, 0, 58.0890f}, {0, 0, 29.4780f}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0} };



    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de MainManager dans la sc�ne !!!");
        }

        instance = this;

        for (int i = 0; i < paletteRGB.GetLength(0); i++)
        {

            paletteRGB[i, 0] = paletteRGB[i, 0] / 255;
            paletteRGB[i, 1] = paletteRGB[i, 1] / 255;
            paletteRGB[i, 2] = paletteRGB[i, 2] / 255;

        }
    }
    private void Start()
    {
        canvasManager.UpdateColorBars(0);
        canvasManager.UpdateSizeColorBar();
    }

    public Color GetColorFromKey(int colorKey)
    {
        return new Color(paletteRGB[colorKey, 0], paletteRGB[colorKey, 1], paletteRGB[colorKey, 2]);
    }


    public string ToBin(int value, int len)
    {
        return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
    }

    public int BinToInt(string bin)
    {
        return Convert.ToInt32(bin, 2);
    }


    public void IfLoose()
    {
        print("Loose !");
    }

    public void ManageCollisionWithPot(int potId)
    {
        // Change canvas

        brush.AddColor(potId);
        CheckIfMatchingColors();
        canvasManager.UpdateColorBars(brush.currentColorKey);

    }
    public void ManageCollisionWithWater()
    {
        print("coucou");
        // substract selcted color on jauge
        if (canvasManager.indexSelectedColorBar != -1)
        {
            print("hey");
            //ColorBar currentColorBar = canvasManager.listColorBar[canvasManager.indexSelectedColorBar];
            brush.SubstractColor(canvasManager.indexSelectedColorBar);
            CheckIfMatchingColors();
            canvasManager.UpdateColorBars(brush.currentColorKey);
        }

    }

    public void CheckIfMatchingColors()
    {
        if (brush.GetBrushColor() == paintingManager.GetPixelColor(paintingManager.pixelTarget))
        {
            print("win");
            paintingManager.UnveilPixelsOfSameColor(paintingManager.GetPixelColor(paintingManager.pixelTarget));
            brush.ResetBrushColor();
            paintingManager.SelectTarget();
        }
    }











}
