using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Win : MonoBehaviour
{
    public float animationTime;

    private int numberGold;
    public TextMeshProUGUI numberGoldText;

    public GameObject animatedGoldPrefab;
    public Transform target;
    public Transform initial;

    public int goldPickedUpInThisLevel;
    public int totalGoldInLevel;
    public TextMeshProUGUI numberGoldTextInLevel;


    private void Start()
    {
        PauseManager.gameIsPaused = true;

        numberGold = MainManager.instance.goldCount;
        totalGoldInLevel = 8;
        goldPickedUpInThisLevel = 8;
        numberGoldText.text = numberGold.ToString();
        numberGoldTextInLevel.text = goldPickedUpInThisLevel.ToString();

        StartCoroutine(UpdateGoldCount());
    }



    
    public void UpdateNumberGold()
    {
        numberGold += 1;
        numberGoldText.text = numberGold.ToString();

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
}
