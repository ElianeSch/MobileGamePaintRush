using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{

    public int currentColorKey;

    private void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            int potId = collision.gameObject.GetComponent<Pot>().potId;
            Destroy(collision.gameObject);
            MainManager.instance.ManageCollisionWithPot(potId);
        }

        else if (collision.gameObject.CompareTag("Eau"))
        {
            MainManager.instance.ManageCollisionWithWater();
        }

    }


    public void AddColor(int colorKey)
    {
        string binColorKey = MainManager.instance.ToBin(colorKey, 8);
        string binCurrentColorKey = MainManager.instance.ToBin(currentColorKey, 8);

        print(binCurrentColorKey);
        print(binColorKey);


        Dictionary<string, int> dic = new Dictionary<string, int> { { "00", 0 }, { "01", 1 }, { "10", 2 }, { "11", 3 } };
        Dictionary<int, string> invDic = new Dictionary<int, string> { {0, "00"}, { 1,"01" }, { 2, "10" }, { 3,"11" } };

        char[] sortie = "00000000".ToCharArray();





        for (int i=0;i<4;i++)
        {
            string subColorKey = binColorKey.Substring(2 * i, 2);
            string subCurrentColorKey = binCurrentColorKey.Substring(2 * i, 2);

            int somme = dic[subColorKey] + dic[subCurrentColorKey];
            
            if (somme > 3)
            {
                print(somme);
                MainManager.instance.IfLoose();
                break; // Game Over
            }

            else
            {
                sortie[2 * i] = invDic[somme][0];
                sortie[2 * i+1] = invDic[somme][1];
            }

        }
        string newBinColor = "";
        foreach (char c in sortie)
            newBinColor += c;


        currentColorKey = MainManager.instance.BinToInt(newBinColor);
        ChangeBrushColor(currentColorKey);

    }

    public void SubstractColor(int currentColorBar)
    {
        string binCurrentColorKey = MainManager.instance.ToBin(currentColorKey, 8);

        Dictionary<string, int> dic = new Dictionary<string, int> { { "00", 0 }, { "01", 1 }, { "10", 2 }, { "11", 3 } };
        Dictionary<int, string> invDic = new Dictionary<int, string> { { 0, "00" }, { 1, "01" }, { 2, "10" }, { 3, "11" } };

        char[] sortie = "00000000".ToCharArray();
        
        string subCurrentColorKey = binCurrentColorKey.Substring(2 * currentColorBar, 2);

        int diff = Mathf.Max(dic[subCurrentColorKey] -1,0);

        sortie[2 * currentColorBar] = invDic[diff][0];
        sortie[2 * currentColorBar + 1] = invDic[diff][1];

        string newBinColor = sortie.ToString();

        currentColorKey = MainManager.instance.BinToInt(newBinColor);
        ChangeBrushColor(currentColorKey);
    }

    public void ChangeBrushColor(int colorKey)
    {
        currentColorKey = colorKey;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = MainManager.instance.GetColorFromKey(colorKey) ;
    }

    public void ChangeBrushColor(Color color)
    {
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
    }


    public Color GetBrushColor()
    {
        return gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color;
    }

    public void ResetBrushColor()
    {
        ChangeBrushColor(0);
    }

}
