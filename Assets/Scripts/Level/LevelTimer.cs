using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI timerText;

    [Header("Time")]
    [SerializeField]
    private float timeElapsed;
    private bool resetTimer;


    // Start is called before the first frame update
    void Start()
    {
        if (resetTimer)
        {
            timeElapsed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed();
    }

    private void TimeElapsed()
    {
        timeElapsed += Time.deltaTime;
        TimerToText();
    }

    private void TimerToText()
    {
        timerText.text = Mathf.Floor(timeElapsed / 60).ToString("00") + (":") + Mathf.Floor(timeElapsed % 60).ToString("00");
    }
}
