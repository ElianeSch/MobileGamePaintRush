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

    private void Awake()
    {
        for (int i=0;i<PaintingsLibrary.spritesList.Count/3;i++)
        {
            int tmp = i;
            GameObject tempObj = Instantiate(panelLevel, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(content.transform, false);
            tempObj.transform.GetChild(1).GetComponent<Image>().sprite = PaintingsLibrary.spritesList[3*i];
            tempObj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { Bouton(tmp); });
            tempObj.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => { Bouton(tmp); });
            listPanels.Add(tempObj);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Bouton(int index)
    {
        levelPreviewPanel.SetActive(true);
        indexLevel = index;

    }

    public void CloseLevelPreviewPanel()
    {
        levelPreviewPanel.SetActive(false);
    }


    public void LauchLevel(int index)
    {
        CurrentLevel.instance.currentLevel = PaintingsLibrary.namesList[indexLevel*3 + index];
        SceneManager.LoadScene("Level01");


    }


}
