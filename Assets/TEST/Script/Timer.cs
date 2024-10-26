using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timer;
    public bool isGameOver = false;
    public string timerMessage;
    [SerializeField] string minutes;
    [SerializeField] string seconds;
    [SerializeField] string milliSeconds;
    [SerializeField] float defaultTimer;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject over;
    [SerializeField] GameObject uI;
    // Start is called before the first frame update
    void Start()
    {
        defaultTimer = timer;
        over.SetActive(false);
        uI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        minutes = ((int)timer/60).ToString();
        seconds = ((int)timer % 60).ToString();
        milliSeconds = ((int)(100*(timer%1))).ToString();
        if (minutes.Length == 1)
        {
            minutes = "0" + minutes;
        }
        if(seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }
        if(milliSeconds.Length == 1)
        {
            milliSeconds = "0" + milliSeconds;
        }
        timerMessage = minutes + ":" + seconds + "." + milliSeconds;
        timerMessage = timerMessage.Replace("0", "〇")
                           .Replace("1", "一")
                           .Replace("2", "二")
                           .Replace("3", "三")
                           .Replace("4", "四")
                           .Replace("5", "五")
                           .Replace("6", "六")
                           .Replace("7", "七")
                           .Replace("8", "八")
                           .Replace("9", "九")
                           .Replace("-","〇");
        text.text = timerMessage;
        if (timer<0)
        {
            isGameOver = true;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if(isGameOver)
        {
            over.SetActive(true);
            uI.SetActive(false);
        }
        image.fillAmount = timer / defaultTimer;
    }
}
