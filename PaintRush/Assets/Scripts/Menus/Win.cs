using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Win : MonoBehaviour
{
    public float animationTime;

    private int savedGold;
    public TextMeshProUGUI numberGoldText;

    public GameObject animatedGoldPrefab;
    public Transform target;
    public Transform initial;

    public int goldPickedUpInThisLevel;
    public int totalGoldInLevel;
    public TextMeshProUGUI numberGoldTextInLevel;

    public Image endImage;
    public int steps;

    private void Start()
    {
        PauseManager.gameIsPaused = true;
        savedGold = GameManager.instance.GetCoinCount();
        goldPickedUpInThisLevel = MainManager.instance.goldCount;
        totalGoldInLevel = goldPickedUpInThisLevel;
        GameManager.instance.SetandSaveCoinCount(savedGold+goldPickedUpInThisLevel);

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
        yield return new WaitForSeconds(2f);
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
        var tempColor = image.color;

        for (int i = 0; i < steps+1; i++)
        {
            tempColor.a = i*1.0f/steps;
            image.color = tempColor;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
