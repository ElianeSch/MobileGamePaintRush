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
            Debug.Log("Plus d'une instance de LoadAndSaveData dans la sc�ne");
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
    public BackgroundColor backgroundColor = new BackgroundColor();

    public void SaveToJson()
    {
        string unlockedData = JsonUtility.ToJson(unlocked);
        string goldData = JsonUtility.ToJson(gold);
        string starData = JsonUtility.ToJson(star);
        string itemsData = JsonUtility.ToJson(unlockedItems);
        string colorBackgroundData = JsonUtility.ToJson(backgroundColor);


        string filePath = Application.persistentDataPath + "/UnlockedData.json";
        string filePathGold = Application.persistentDataPath + "/GoldData.json";
        string filePathStar = Application.persistentDataPath + "/StarData.json";
        string filePathItem = Application.persistentDataPath + "/ItemData.json";
        string filePathColorBackground = Application.persistentDataPath + "/ColorBackgroundData.json";

        System.IO.File.WriteAllText(filePath, unlockedData);
        System.IO.File.WriteAllText(filePathGold, goldData);
        System.IO.File.WriteAllText(filePathStar, starData);
        System.IO.File.WriteAllText(filePathItem, itemsData);
        System.IO.File.WriteAllText(filePathColorBackground, colorBackgroundData);


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

        if (System.IO.File.Exists(Application.persistentDataPath + "/ColorBackgroundData.json"))
        {
            string filePathColorBackground = Application.persistentDataPath + "/ColorBackgroundData.json";
            string colorBackgroundData = System.IO.File.ReadAllText(filePathColorBackground);

            backgroundColor = JsonUtility.FromJson<BackgroundColor>(colorBackgroundData);

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
    public List<int> unlockedBrushIndex = new List<int>();
    public List<int> unlockedBackgroundIndex = new List<int>();
    public int currentBrushIndex;
    public int currentBackgroundIndex;
}

public class BackgroundColor
{
    public Color colorBackground;
    public bool backgroundIsColored;
}



