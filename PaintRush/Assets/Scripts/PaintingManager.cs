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

    public string filePath;

    public Dictionary<Color, List<GameObject>> dictPixelByColor = new Dictionary<Color, List<GameObject>>();

    public GameObject pixelTarget;



    private void Awake()
    {
        ReadTableau(filePath);

    }

    void Start()
    {
        CreatePixels();
        SelectTarget();
  
        





        //int indice = listePixels[BrushManager.instance.indexOfCurrentPixel];
        //Color targetColor = new Color(MainManager.instance.paletteRGB[indice, 0], MainManager.instance.paletteRGB[indice, 1], MainManager.instance.paletteRGB[indice, 2]);
        //Pinceau.instance.targetColor = targetColor;
        //listeImagesPixel[Pinceau.instance.indexOfCurrentPixel].GetComponent<Image>().color = targetColor;
    }

    void ReadTableau(string file_path)
    {
        StreamReader file = new StreamReader(file_path);
        bool taille = false;
        while (!file.EndOfStream)
        {
            string line = file.ReadLine();
            string[] liste = line.Split('\t');

            if(!taille)
            {
                N = int.Parse(liste[0]);
                M = int.Parse(liste[1]);
                taille = true;
            }
            else
            {
                foreach (string item in liste)
                {
                    int indexColor = int.Parse(item);
                    listIndexColor.Add(indexColor);
                }
            }
         
        }

        file.Close();
    }

    void CreatePixels()
    {
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = M;

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
        else print("Wiiiin");
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
            print("ici");
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
