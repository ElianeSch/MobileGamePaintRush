using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System;

public class PaintingManager : MonoBehaviour
{
    public int N; // Nombre de colonnes
    public int M; // Nombre de lignes 
    public List<int> listIndexColor = new List<int>(); // Contient les indices correspondant aux couleurs de la peinture cible (c'est tableau NH par exemple)


    public List<GameObject> listPixel = new List<GameObject>();
    public GridLayoutGroup grid;
    public GameObject pixel; // L'image du pixel

    public Dictionary<Color, List<GameObject>> dictPixelByColor = new Dictionary<Color, List<GameObject>>();

    public GameObject pixelTarget;

    public string paintingName;



    public void ReadTableau(int PaintingID, int difficulty)
    {

        List<int> painting = PaintingsLibrary.instance.GetPainting(PaintingID, difficulty);
       

        N = painting[0];
        M = painting[1];
        listIndexColor = painting.GetRange(2,painting.Count-2);
    }

    public void CreatePixels()
    {
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = M;
        float a = Mathf.Min(grid.GetComponent<RectTransform>().rect.width / M, grid.GetComponent<RectTransform>().rect.height / N);
        grid.cellSize = new Vector2(a,a);
        RectTransform rt = grid.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(M * a, N * a);

        for (int i = 0; i < N * M; i++)
        {
            GameObject tempObj = Instantiate(pixel, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(grid.transform, false);

            Color tempColor = MainManager.instance.GetColorFromKey(listIndexColor[i]);
            tempObj.GetComponent<Image>().color = tempColor;


            if (!dictPixelByColor.ContainsKey(tempColor))
            {
                dictPixelByColor[tempColor] = new List<GameObject> {tempObj};
            }

            else
            {
                dictPixelByColor[tempColor].Add(tempObj);
            }

            tempObj.GetComponent<Image>().color = new Color(tempColor.r, tempColor.g, tempColor.b, 0f);
            listPixel.Add(tempObj);


        }


    }

    public void SelectTarget()
    {
        if (dictPixelByColor.Count > 0)
        {
            System.Random random = new System.Random();
            List<GameObject> colorTarget = dictPixelByColor.ElementAt(random.Next() % (dictPixelByColor.Count)).Value;
            pixelTarget = colorTarget[random.Next() % colorTarget.Count];
            UnveilPixel(pixelTarget);
        }
        else
        {
            MainManager.instance.Win(); //Bravo !
        }
        
    }

    void UnveilPixel(GameObject pixel)
    {
        Color tempColor = pixel.GetComponent<Image>().color;
        pixel.GetComponent<Image>().color = new Color(tempColor.r, tempColor.g, tempColor.b, 1f);
    }

    public void UnveilPixelsOfSameColor(Color color)
    {

        if (dictPixelByColor.ContainsKey(color))
        {
  
            foreach (GameObject pixel in dictPixelByColor[color])
            {
                pixel.GetComponent<Image>().color = color;
            }

            dictPixelByColor.Remove(color);
        }

    }

    public Color GetPixelColor(GameObject pixel)
    {
        return pixel.GetComponent<Image>().color;
    }

}
