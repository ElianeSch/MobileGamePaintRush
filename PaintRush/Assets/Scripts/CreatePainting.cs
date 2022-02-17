using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CreatePainting : MonoBehaviour
{
    public int N; // Nombre de colonnes
    public int M; // Nombre de lignes
    public int[] listePixels;

    private int[] tableauNH = new int[] {         106,

    26,

    22,
        
   106,

    86,

   170,

   170,

   170,

   170,

   170,

    86,

    86,

   150,

   150,

    66,

     6,

    88,

    88,

   170,

   170,

    86,

   150,

   150,

   150,

    86,

     5,

    88,

    66,

    66,

    66,

   150,

   170,

   106,

    22,

    90,

    26,

    69,

    69,

    69,

    70,

    70,

    66,

   150,

   170,
   
   170
};





    public List<GameObject> listeImagesPixel = new List<GameObject>();
    public GridLayoutGroup grid;
    public GameObject pixel; // L'image du pixel


    public static CreatePainting instance;

    private void Awake()
    {

        instance = this;

        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = N;

        for (int i = 0; i < N * M; i++)
        {
            GameObject tempObj = Instantiate(pixel, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(grid.transform, false);
            listeImagesPixel.Add(tempObj);
        }

        listePixels = tableauNH;


    }

    void Start()
    {
        print(listePixels[0]);
        // Mettre ici la couleur des pixels récupérés sur l'image dans ReadImage

        int indice = listePixels[Pinceau.instance.indexOfCurrentPixel];
        Color targetColor = new Color(Pinceau.instance.paletteRGB[indice, 0], Pinceau.instance.paletteRGB[indice, 1], Pinceau.instance.paletteRGB[indice, 2]);
        Pinceau.instance.targetColor = targetColor;
        listeImagesPixel[Pinceau.instance.indexOfCurrentPixel].GetComponent<Image>().color = targetColor;
    }

}
