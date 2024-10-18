using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public float timer;
    public bool isGameOver = false;
    public string timerMessage;
    [SerializeField] string minutes;
    [SerializeField] string seconds;
    [SerializeField] string milliSeconds;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(timer<0)
        {
            isGameOver = true;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
