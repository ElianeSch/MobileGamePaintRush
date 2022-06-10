using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{

    public int currentColorKey;
    public LineRenderer trailEffect;

    public GameObject colorBrush;

    public GameObject meshBrush;

    public GameObject brushObject;
    public GameObject newBrush;

    private void Awake()
    {

        
        GameManager.instance.LoadData();

        if (GameManager.instance.currentBrushIndex != -1)
        {
            brushObject =  GameManager.instance.allBrush[GameManager.instance.currentBrushIndex].mesh;
        }

        else
        {
            print("null");
            brushObject = meshBrush;
        }

        
        newBrush = Instantiate(brushObject, gameObject.transform);

        colorBrush = newBrush.transform.Find("PaintBrush").gameObject;
        trailEffect = newBrush.GetComponentInChildren<LineRenderer>();


        ResetBrushColor();


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
            Destroy(collision.gameObject);
            MainManager.instance.ManageCollisionWithWater();
        }


        else if (collision.gameObject.CompareTag("Gold"))
        {
            
            MainManager.instance.ManageCollisionWithGold(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }


    public void AddColor(int colorKey)
    {
        string binColorKey = MainManager.instance.ToBin(colorKey, 8);
        string binCurrentColorKey = MainManager.instance.ToBin(currentColorKey, 8);

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

        char[] sortie = binCurrentColorKey.ToCharArray();
        string subCurrentColorKey = binCurrentColorKey.Substring(2 * currentColorBar, 2);
        int diff = Mathf.Max(dic[subCurrentColorKey] -1,0);

        sortie[2 * currentColorBar] = invDic[diff][0];
        sortie[2 * currentColorBar + 1] = invDic[diff][1];

        string newBinColor = "";
        foreach (char c in sortie)
            newBinColor += c;

        currentColorKey = MainManager.instance.BinToInt(newBinColor);
        ChangeBrushColor(currentColorKey);
    }

    public void ChangeBrushColor(int colorKey)
    {

        StartCoroutine(ChangeGradient(colorKey));
        
        currentColorKey = colorKey;
        colorBrush.GetComponent<Renderer>().sharedMaterial.color = MainManager.instance.GetColorFromKey(colorKey);

    }

    public void ChangeBrushColor(Color color)
    {
        StartCoroutine(ChangeGradient(color));

        colorBrush.GetComponent<Renderer>().sharedMaterial.color = color;

    }


    public Color GetBrushColor()
    {
        return colorBrush.GetComponent<Renderer>().sharedMaterial.color;
    }

    public void ResetBrushColor()
    {
        ChangeBrushColor(0);
    }

    public IEnumerator ChangeGradient(Color color)
    {
        float elapsedTime = 0f;
        float totalTime = 1f;

        Color brushColor = GetBrushColor();

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            trailEffect.sharedMaterial.color = Color.Lerp(brushColor, color, elapsedTime / totalTime);
            yield return null;
        }
    }

    public IEnumerator ChangeGradient(int colorKey)
    {
        float elapsedTime = 0f;
        float totalTime = 1f;

        Color brushColor = GetBrushColor();

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            Color color = MainManager.instance.GetColorFromKey(colorKey);
            trailEffect.sharedMaterial.color = Color.Lerp(brushColor, color, elapsedTime / totalTime);
            yield return new WaitForEndOfFrame();
        }
    }


}
