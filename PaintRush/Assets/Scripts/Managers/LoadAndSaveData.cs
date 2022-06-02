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
    public Coin gold = new Coin();
    public Stars star = new Stars();

    public void SaveToJson()
    {
        string unlockedData = JsonUtility.ToJson(unlocked);
        string goldData = JsonUtility.ToJson(gold);
        string starData = JsonUtility.ToJson(star);


        string filePath = Application.persistentDataPath + "/UnlockedData.json";
        string filePathGold = Application.persistentDataPath + "/GoldData.json";
        string filePathStar = Application.persistentDataPath + "/StarData.json";

        System.IO.File.WriteAllText(filePath, unlockedData);
        System.IO.File.WriteAllText(filePathGold, goldData);
        System.IO.File.WriteAllText(filePathStar, starData);


        Debug.Log("Sauvegarde effectuée");
    }


    public void LoadFromJson()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/UnlockedData.json"))
            {
            string filePath = Application.persistentDataPath + "/UnlockedData.json";
            string unlockedData = System.IO.File.ReadAllText(filePath);

            unlocked = JsonUtility.FromJson<UnlockedPaintings>(unlockedData);

            }

        if (System.IO.File.Exists(Application.persistentDataPath + "/GoldData.json"))
        {
            string filePathGold = Application.persistentDataPath + "/GoldData.json";
            string goldData = System.IO.File.ReadAllText(filePathGold);

            gold = JsonUtility.FromJson<Coin>(goldData);

        }


        if (System.IO.File.Exists(Application.persistentDataPath + "/StarData.json"))
        {
            string filePathStar = Application.persistentDataPath + "/StarData.json";
            string starData = System.IO.File.ReadAllText(filePathStar);

            star = JsonUtility.FromJson<Stars>(starData);

        }




    }


}


[System.Serializable]
public class UnlockedPaintings

{
    public List<int> difficultyUnlocked = new List<int>();
}

[System.Serializable]
public class Coin
{
    public int totalGoldCount;
}


[System.Serializable]
public class Stars
{
    public int totalStarCount = 0;
    public int starsToUnlockLevel;
}


