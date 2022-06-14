using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "painting", menuName = "Scriptable objects/New Painting", order = 1)]
public class PaintingSO : ScriptableObject
{
    public string paintingName;

    [TextArea(3, 10)]
    public string description;

    public Sprite[] spritesPainting ;
    public Painting painting;

    public string movement;

    public string questionQuiz;

    public string answerQuiz1;
    public string answerQuiz2;
    public string answerQuiz3;
    public string answerQuiz4;


    public void GetPaintingInfo()
    {
        spritesPainting = Resources.LoadAll<Sprite>("Paintings/" + name);
        var jsonTextFile = Resources.Load<TextAsset>("PaintingsJson/" + name);
        string jsonString = jsonTextFile.ToString();
        painting = JsonUtility.FromJson<Painting>(jsonString);
    }




    [Serializable]
    public class Painting
    {
        public List<int> Easy;
        public List<int> Medium;
        public List<int> Hard;

    }

}

