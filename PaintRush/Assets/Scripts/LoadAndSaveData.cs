using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadAndSaveData : MonoBehaviour
{


    // On veut sauvegarder :
    /* la liste des noms des tableaux débloqués, -1 si pas débloqué, 3 si fini
     * la liste des la dernière difficulté débloquée pour chaque tableau
     * ("kanagawa", 0)
     * 
     * */

    public static LoadAndSaveData instance;


    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de LoadAndSaveData dans la scène");
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
        Debug.Log("Sauvegarde effectuée");
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
