using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI uiText;
    public int countDownNumber = 3;
    public GameObject countDown;
    public Timer timer;
    public PlayerMovement playerMovement;
    public Button pauseButton;

   private void Start()
    {
        timer.uiText.text = timer.duration.ToString();
        timer.enabled = false;
        playerMovement.enabled = false;
        pauseButton.interactable = false;
        StartCoroutine(StartCountdown());
    }
    public IEnumerator StartCountdown()
    {
        uiText.text = countDownNumber.ToString();
        PauseManager.gameIsPaused = false;
        while (countDownNumber > 1)
        {
            if (PauseManager.gameIsPaused == false)
            {
                yield return new WaitForSeconds(1f);
                countDownNumber -= 1;
                uiText.text = countDownNumber.ToString();
            }


        }

        yield return new WaitForSeconds(1f);
        uiText.text = "GO !";
        yield return new WaitForSeconds(1f);
        uiText.text = "";
        playerMovement.enabled = true;
        CountDownEnd();
    }

    public void CountDownEnd()
    {
        StopCoroutine("StartCountDown");
        pauseButton.interactable = true;
        timer.enabled = true;
        countDown.SetActive(false);
    }




}
