using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadAndSaveData : MonoBehaviour
{

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
    public UnlockedItems unlockedItems = new UnlockedItems();

    public void SaveToJson()
    {
        string unlockedData = JsonUtility.ToJson(unlocked);
        string goldData = JsonUtility.ToJson(gold);
        string starData = JsonUtility.ToJson(star);
        string itemsData = JsonUtility.ToJson(unlockedItems);


        string filePath = Application.persistentDataPath + "/UnlockedData.json";
        string filePathGold = Application.persistentDataPath + "/GoldData.json";
        string filePathStar = Application.persistentDataPath + "/StarData.json";
        string filePathItem = Application.persistentDataPath + "/ItemData.json";

        System.IO.File.WriteAllText(filePath, unlockedData);
        System.IO.File.WriteAllText(filePathGold, goldData);
        System.IO.File.WriteAllText(filePathStar, starData);
        System.IO.File.WriteAllText(filePathItem, itemsData);


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

        if (System.IO.File.Exists(Application.persistentDataPath + "/ItemData.json"))
        {
            string filePathItem = Application.persistentDataPath + "/ItemData.json";
            string itemsData = System.IO.File.ReadAllText(filePathItem);

            unlockedItems = JsonUtility.FromJson<UnlockedItems>(itemsData);

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

[System.Serializable]

public class UnlockedItems
{
    public List<PinceauSO> items = new List<PinceauSO>();
    public PinceauSO currentBrush;
}




