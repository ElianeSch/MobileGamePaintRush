using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Win : MonoBehaviour
{
    public float animationTime;

    private int savedGold;
    private int savedStars;


    public TextMeshProUGUI numberGoldText;

    public GameObject animatedGoldPrefab;
    public Transform target;
    public Transform initial;

    public int goldPickedUpInThisLevel;
    public int totalGoldInLevel;
    public TextMeshProUGUI numberGoldTextInLevel;

    public Image endImage;
    public int steps;

    public PaintingManager paintingManager;

    private void Start()
    {
        print("coucou");
        PauseManager.gameIsPaused = true;

        savedGold = GameManager.instance.GetCoinCount();
        savedStars = GameManager.instance.GetStarsCount();

        goldPickedUpInThisLevel = MainManager.instance.goldCount;
        totalGoldInLevel = goldPickedUpInThisLevel;

        GameManager.instance.SetandSaveCoinCount(savedGold+goldPickedUpInThisLevel);


        if (GameManager.instance.difficultyUnlocked[GameManager.instance.indexLevel] == GameManager.instance.difficulty) // Si on vient de finir pour la première fois cette difficulté
        {
            GameManager.instance.SetAndSaveStarCount(savedStars + 1);
            print("savedStars + 1 " + savedStars + 1);
            GameManager.instance.difficultyUnlocked[GameManager.instance.indexLevel] += 1;
            LoadAndSaveData.instance.SaveToJson();
            print("totalStarcount : " + GameManager.instance.totalStarCount);
        }

        else
        {
            GameManager.instance.SetAndSaveStarCount(savedStars);
        }

        numberGoldText.text = savedGold.ToString();
        numberGoldTextInLevel.text = goldPickedUpInThisLevel.ToString();

        endImage.sprite = PaintingsLibrary.instance.paintingsList[GameManager.instance.indexLevel].spritesPainting[GameManager.instance.difficulty];

        StartCoroutine(FadeImage(steps));
        StartCoroutine(UpdateGoldCount());
    }



    
    public void UpdateNumberGold()
    {
        savedGold += 1;
        numberGoldText.text = savedGold.ToString();

    }

    public void UpdateNumberGoldInLevel()
    {
        goldPickedUpInThisLevel -= 1;
        numberGoldTextInLevel.text = goldPickedUpInThisLevel.ToString();

    }




    public IEnumerator UpdateGoldCount()
    {
        yield return new WaitForSeconds(1.5f);

        animationTime = animationTime / totalGoldInLevel;

        for (int i = 0; i< totalGoldInLevel; i++)
        {
            GameObject coin = Instantiate(animatedGoldPrefab);
            coin.transform.SetParent(initial);
            coin.transform.localPosition = new Vector3(0, 0, 0);
            iTween.MoveTo(coin, iTween.Hash("position", target.position, "time", animationTime, "easetype", iTween.EaseType.easeInOutSine));
            UpdateNumberGold();
            UpdateNumberGoldInLevel();

            yield return new WaitForSeconds(animationTime);
            Destroy(coin);
        }

    }

    public IEnumerator FadeImage(int steps)
    {

        Image image = endImage.GetComponent<Image>();
        int M = paintingManager.M;
        int N = paintingManager.N;
        float a = Mathf.Min(image.GetComponent<RectTransform>().rect.width / M, image.GetComponent<RectTransform>().rect.height / N);
       
        RectTransform rt = image.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(M * a, N * a);

        var tempColor = image.color;

        for (int i = 0; i < steps+1; i++)
        {
            tempColor.a = i*1.0f/steps;
            image.color = tempColor;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
