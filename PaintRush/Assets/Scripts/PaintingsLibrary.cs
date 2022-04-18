using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class PaintingsLibrary : MonoBehaviour
{

    public Dictionary<string, Painting> paintingsDict = new Dictionary<string, Painting> ();
    public List<Sprite[]> spritesList = new List<Sprite[]>();
    public List<string> namesList = new List<string>();

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



        foreach (string name in namesList)
        {
            Sprite[] spritesPainting = Resources.LoadAll<Sprite>("Paintings/" + name);
            spritesList.Add(spritesPainting);

            var jsonTextFile = Resources.Load<TextAsset>("PaintingsJson/" + name);
            string jsonString = jsonTextFile.ToString();
            Painting painting = JsonUtility.FromJson<Painting>(jsonString);
            paintingsDict.Add(name, painting);



        }
    }

    private void Start()

    {

       
    }


}

[Serializable]
public class Painting
{

    public List<int> Easy;
    public List<int> Medium;
    public List<int> Hard;

}
