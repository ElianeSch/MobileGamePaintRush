using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GalleryManager : MonoBehaviour
{

    public GameObject panelOpenPainting;

    public GameObject panelFrames;

    public GameObject prefabFrame;
    public List<Vector3> listFramesPositions;
    public List<Image> listImages;


    public int numberOfPaintingsFinished = 0;
    public List<int> listFinishedPaintings = new List<int>();

    public TextMeshProUGUI description;


    private void Start()
    {
        for (int i = 0; i < GameManager.instance.difficultyUnlocked.Count; i++)
        {
            if (GameManager.instance.difficultyUnlocked[i] == 3 && PaintingsLibrary.instance.paintingsList[i].movement == GameManager.instance.movement)
            {
                numberOfPaintingsFinished += 1;
                listFinishedPaintings.Add(i);
            }
        }
        print(numberOfPaintingsFinished);
        //numberOfPaintingsFinished = 2;
        //listFinishedPaintings.Add(0);
        //listFinishedPaintings.Add(2);
        CreateAllFrames(numberOfPaintingsFinished);
    }



    public void ClickOnPainting(int index)
    {
        panelOpenPainting.SetActive(true);

        for(int i = 0;i < 4; i++)
        {
            listImages[i].sprite = PaintingsLibrary.instance.paintingsList[index].spritesPainting[i];
        }
        description.text = PaintingsLibrary.instance.paintingsList[index].description;
  
    }

    public void ClosePanelInfo()
    {
        panelOpenPainting.SetActive(false);
    }

    public void CreateAllFrames(int numberOfPaintingsFinished)
    {
        foreach(int index in listFinishedPaintings)
        { 
            GameObject newFrame = Instantiate(prefabFrame, listFramesPositions[index], Quaternion.identity);
            newFrame.transform.parent = panelFrames.transform;
            newFrame.GetComponent<Button>().onClick.AddListener(() => {ClickOnPainting(index); });

        }
    }



}
