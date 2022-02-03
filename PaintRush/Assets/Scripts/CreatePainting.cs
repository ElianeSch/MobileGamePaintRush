using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CreatePainting : MonoBehaviour
{
    public int N; // Nombre de colonnes
    public int M; // Nombre de lignes
    public int[] listePixels; // On donne en entrée une liste d'entiers qui correspondent aux N*M couleurs (id) des pixels

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

    }

    void Start()
    {
        int indice = listePixels[Pinceau.instance.indexOfCurrentPixel];
        Color targetColor = new Color(Pinceau.instance.paletteRGB[indice, 0], Pinceau.instance.paletteRGB[indice, 1], Pinceau.instance.paletteRGB[indice, 2]);
        Pinceau.instance.targetColor = targetColor;
        listeImagesPixel[Pinceau.instance.indexOfCurrentPixel].GetComponent<Image>().color = targetColor;
    }

}
