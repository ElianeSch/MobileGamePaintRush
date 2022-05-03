using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public GameObject levelPreviewPanel;
    public PaintingsLibrary PaintingsLibrary;
    public GameObject content;
    public GameObject panelLevel;

    public List<GameObject> listPanels = new List<GameObject>();

    public int indexLevel;


    public Sprite lockedSprite;
    public Sprite questionSprite;

    public List<Button> listButtons = new List<Button>();
    List<int> difficultyUnlocked;



    // Start is called before the first frame update
    void Start()
    {
        difficultyUnlocked  = GameManager.instance.difficultyUnlocked;
        if(difficultyUnlocked.Count == 0)
        {
            difficultyUnlocked = new List<int>();
            foreach(string name in PaintingsLibrary.instance.namesList)
             {
                difficultyUnlocked.Add(0);
            }
            LoadAndSaveData.instance.unlocked.difficultyUnlocked = difficultyUnlocked;
            LoadAndSaveData.instance.SaveToJson();

            GameManager.instance.LoadData();
        }

        for (int i = 0; i < PaintingsLibrary.spritesList.Count; i++)
        {
            int tmp = i;
            GameObject tempObj = Instantiate(panelLevel, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(content.transform, false);

            tempObj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { Bouton(tmp); });
            tempObj.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => { Bouton(tmp); });


            if (difficultyUnlocked[i] == -1) // sprite locked
            {
                tempObj.transform.GetChild(1).GetComponent<Image>().sprite = lockedSprite;
                tempObj.transform.GetChild(0).GetComponent<Button>().interactable = false;
                tempObj.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }

            else if (difficultyUnlocked[i] == 0)
            {
                tempObj.transform.GetChild(1).GetComponent<Image>().sprite = questionSprite;
            }

            else
            {
               // print(PaintingsLibrary.spritesList[i]);
                //print(difficultyUnlocked[i - 1]);
                tempObj.transform.GetChild(1).GetComponent<Image>().sprite = PaintingsLibrary.spritesList[i][difficultyUnlocked[i]-1];
            }





            listPanels.Add(tempObj);
        }

        InactivateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Bouton(int index)
    {
        levelPreviewPanel.SetActive(true);
        int maxDifficulty = difficultyUnlocked[index];

        for (int i=0;i<3;i++)
        {
            if (i<=maxDifficulty)
            {
                listButtons[i].interactable = true;
            }
        }

        indexLevel = index;
        GameManager.instance.currentLevel = PaintingsLibrary.namesList[indexLevel];
        GameManager.instance.indexLevel = indexLevel;

    }

    public void CloseLevelPreviewPanel()
    {
        InactivateButtons();
        levelPreviewPanel.SetActive(false);

    }


    public void LauchLevel(int index)
    {
        GameManager.instance.difficulty = index;
        InactivateButtons();
        GameManager.instance.LoadMainScene();


    }

    public void InactivateButtons()
    {
        for (int i = 0; i < 3; i++)
        {
           listButtons[i].interactable = false;
        }
    }


}
