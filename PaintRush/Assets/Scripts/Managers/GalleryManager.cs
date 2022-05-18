using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{


    public Animator animatorScrollingPainting;
    public GameObject panelOpenPainting;

    public GameObject panelFrames;
    public int indexScrollPreview = 0;

    public GameObject prefabFrame;
    public List<Vector3> listFramesPositions;
    public List<Image> listImages;


    public int numberOfPaintingsFinished = 0;
    public List<int> listFinishedPaintings = new List<int>();


    private void Start()
    {
        for (int i = 0; i < GameManager.instance.difficultyUnlocked.Count; i++)
        {
            if (GameManager.instance.difficultyUnlocked[i] == 3)
            {
                numberOfPaintingsFinished += 1;
                listFinishedPaintings.Add(i);
            }
        }
        numberOfPaintingsFinished = 2;
        listFinishedPaintings.Add(0);
        listFinishedPaintings.Add(2);
        CreateAllFrames(numberOfPaintingsFinished);
    }

    public void ClickButtonRight()
    {
        if (indexScrollPreview < 3)
        {
            indexScrollPreview += 1;
            animatorScrollingPainting.SetInteger("indexPreview", indexScrollPreview);
        }

    }

    public void ClickButtonLeft()
    {
        if (indexScrollPreview > 0)
        {
            indexScrollPreview -= 1;
            animatorScrollingPainting.SetInteger("indexPreview", indexScrollPreview);
        }
    }


    public void ClickOnPainting(int index)
    {
        panelOpenPainting.SetActive(true);
        for(int i = 0;i < 3; i++)
        {
            listImages[i].sprite = PaintingsLibrary.instance.spritesList[index][i];
        }
  
    }

    public void ClosePanelInfo()
    {
        indexScrollPreview = 0;
        animatorScrollingPainting.SetInteger("indexPreview", indexScrollPreview);
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
