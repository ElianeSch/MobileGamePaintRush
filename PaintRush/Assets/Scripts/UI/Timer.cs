using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    public TextMeshProUGUI uiText;

    public float duration;
    private float timeLeft;



    private void Start()
    {
        timeLeft = duration;
        uiText.text = Mathf.RoundToInt(timeLeft).ToString();

    }

    private void Update()
    {
        if (timeLeft >= 0)
        {
            if (PauseManager.gameIsPaused == false)
            {
                timeLeft -= Time.deltaTime;
                uiText.text = Mathf.RoundToInt(timeLeft).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, duration, timeLeft);
            }

        }
    }




}
