using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{


    public static MainManager instance;

    public Brush brush;
    public Canvas canvas;
    public PaintingManager paintingManager;
    public CanvasManager canvasManager;
    public GameObject winPanel;

    public int goldCount = 0;
    public GameObject numGold;

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
        winPanel.SetActive(false);
        paintingManager.ReadTableau(GameManager.instance.currentLevel, GameManager.instance.difficulty);
        paintingManager.CreatePixels();
        paintingManager.SelectTarget();
        canvasManager.UpdateColorBars(0);
        canvasManager.UpdateSizeColorBar();
        canvasManager.UpdateTargetImage(paintingManager.pixelTarget.GetComponent<Image>().color);
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


    public void ManageCollisionWithPot(int potId)
    {
        // Change canvas

        brush.AddColor(potId);
        CheckIfMatchingColors();
        canvasManager.UpdateColorBars(brush.currentColorKey);

    }
    public void ManageCollisionWithWater()
    {
        // substract selcted color on jauge
        if (canvasManager.indexSelectedColorBar != -1)
        {
            //ColorBar currentColorBar = canvasManager.listColorBar[canvasManager.indexSelectedColorBar];
            brush.SubstractColor(canvasManager.indexSelectedColorBar);
            CheckIfMatchingColors();
            canvasManager.UpdateColorBars(brush.currentColorKey);
        }

    }


    public void ManageCollisionWithGold(GameObject other)
    {
        goldCount += 1;
        canvasManager.UpdateGoldCount(goldCount);
        Destroy(Instantiate(numGold, new Vector3(0,0,-2), Quaternion.identity), 1f);

    }



    public void CheckIfMatchingColors()
    {
        if (brush.GetBrushColor() == paintingManager.GetPixelColor(paintingManager.pixelTarget))
        {
            paintingManager.UnveilPixelsOfSameColor(paintingManager.GetPixelColor(paintingManager.pixelTarget));
            brush.ResetBrushColor();
            paintingManager.SelectTarget();
            canvasManager.UpdateTargetImage(paintingManager.pixelTarget.GetComponent<Image>().color);
        }
    }

    public void Win()
    {
        winPanel.SetActive(true);
        if (GameManager.instance.difficultyUnlocked[GameManager.instance.indexLevel] <= 2)
        { 
            LoadAndSaveData.instance.unlocked.difficultyUnlocked[GameManager.instance.indexLevel]++;
        }
        LoadAndSaveData.instance.SaveToJson();
        GameManager.instance.LoadData();
    }

    public void IfLoose()
    {

    }

    public void LoadNext()
    {
        StopAllCoroutines();
        GameManager.instance.LoadNext();
    }
    public void LoadMainMenu()
    {
        StopAllCoroutines();
        GameManager.instance.LoadMenu();
    }









}
