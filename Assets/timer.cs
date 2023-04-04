using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stopwatch;
    private float currentTime;
    private bool timeStart;
    private LoadNextScene load;
    // Start is called before the first frame update
    void Start()
    {
        timeStart = true;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeStart == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        //converts time to minutes + seconds and presents in nice format
        TimeSpan niceTime = TimeSpan.FromSeconds(currentTime);

        stopwatch.SetText(niceTime.ToString(@"mm\:ss"));
        if(load.levelDone == true)
        {
            //stops timer when level is completed
            stopTimer();
        }
    }

    void stopTimer()
    {
        timeStart = false;
    }
}
