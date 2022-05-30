using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class PaintingsLibrary : MonoBehaviour
{

    public List<PaintingSO> paintingsList = new List<PaintingSO>();

    public static PaintingsLibrary instance;


    private void Awake()
    {

        if (instance != null)
        {
            Debug.Log("Plus d'une instance de PaintingsLibrary dans la scène !");
        }

        else
        {
            instance = this;
        }


        foreach(PaintingSO painting in paintingsList)
        {
            painting.GetPaintingInfo();
        }


        

    }
    public List<int> GetPainting(int PaintingID, int difficulty)
    {
        List<int> painting = new List<int>();
        if (difficulty == 0)
        {
            painting = paintingsList[PaintingID].painting.Easy;
        }

        else if (difficulty == 1)
        {
            painting = paintingsList[PaintingID].painting.Medium;
        }

        else
        {
            painting = paintingsList[PaintingID].painting.Hard;
        }
        return painting;
    }

}

[Serializable]
public class Painting
{

    public List<int> Easy;
    public List<int> Medium;
    public List<int> Hard;

}
