using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

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

    public GameObject tableauPanel;

    public GameObject quizPanel;
    private bool quiz = false;

    public PaintingManager paintingManager;

    private void Start()
    {

        PauseManager.gameIsPaused = true;

        savedGold = GameManager.instance.GetCoinCount();
        savedStars = GameManager.instance.GetStarsCount();

        goldPickedUpInThisLevel = MainManager.instance.goldCount;
        totalGoldInLevel = goldPickedUpInThisLevel;

        GameManager.instance.SetandSaveCoinCount(savedGold+goldPickedUpInThisLevel);


        if (GameManager.instance.difficultyUnlocked[GameManager.instance.indexLevel] == GameManager.instance.difficulty) // Si on vient de finir pour la première fois cette difficulté
        {
            if (GameManager.instance.difficultyUnlocked[GameManager.instance.indexLevel] == 2)
            {
                quiz = true;
            }


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

        tableauPanel.transform.SetParent(gameObject.transform);
        tableauPanel.transform.SetAsFirstSibling();

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

        if (quiz) // Si on a débloqué le tableau
        {
            QuizPanel();
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



    public void QuizPanel()
    {
        print("quiz !");
        quizPanel.SetActive(true);


        // Gérer le quiz : récupérer la question et les 4 réponses
        // Afficher les réponses à des boutons aléatoires

        Button[] buttonsAnswers = quizPanel.GetComponentsInChildren<Button>();

        PaintingSO painting = PaintingsLibrary.instance.paintingsList[GameManager.instance.indexLevel];

       
        List<int> usedValues = new List<int>();

        for (int i = 0; i<4; i++)
        {
            int index = Random.Range(0, 4);

            while (usedValues.Contains(index))
            {
                index = Random.Range(0, 4);
            }

            usedValues.Add(index);

            AddButtonListener(buttonsAnswers[i], index);

            buttonsAnswers[i].GetComponentInChildren<TextMeshProUGUI>().text = painting.answers[index];

        }



    }

    void AddButtonListener(Button b, int index)
    {
        if (index == 0)
            b.onClick.AddListener(() => { ClickOnGoodAnswer(); });
        else
            b.onClick.AddListener(() => { ClickOnBadAnswer(); });
    }


    public void ClickOnGoodAnswer()
    {
        print("Good Answer !");
    }

    public void ClickOnBadAnswer()
    {
        print("Bad answer !");
    }

}
