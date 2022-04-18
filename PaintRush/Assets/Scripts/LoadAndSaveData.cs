using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadAndSaveData : MonoBehaviour
{


    // On veut sauvegarder :
    /* la liste des noms des tableaux d�bloqu�s, -1 si pas d�bloqu�, 3 si fini
     * la liste des la derni�re difficult� d�bloqu�e pour chaque tableau
     * ("kanagawa", 0)
     * 
     * */

    public static LoadAndSaveData instance;


    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de LoadAndSaveData dans la sc�ne");
        }

        else
        {
            instance = this;
        }
    }

    public UnlockedPaintings unlocked = new UnlockedPaintings();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadFromJson();
        }


    }

    public void SaveToJson()
    {
        string unlockedData = JsonUtility.ToJson(unlocked);
        string filePath = Application.persistentDataPath + "/UnlockedData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, unlockedData);
        Debug.Log("Sauvegarde effectu�e");
    }


    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/UnlockedData.json";
        string unlockedData = System.IO.File.ReadAllText(filePath);

        unlocked = JsonUtility.FromJson<UnlockedPaintings>(unlockedData);
        Debug.Log("Load data");


    }


}


[System.Serializable]
public class UnlockedPaintings

{
    public List<int> difficultyUnlocked = new List<int>();
}
