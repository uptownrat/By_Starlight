using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stopwatch;
    private float currentTime;
    private bool timeStart;
    [SerializeField] private LoadNextScene load;

    [SerializeField] float threeStar, twoStar, oneStar; //noStar;
    [SerializeField] GameObject threeWin, twoWin, oneWin;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = true;
        currentTime = 0;
        threeWin.SetActive(false);
        twoWin.SetActive(false);
        oneWin.SetActive(false);
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
        //stops timer when level is completed
        if (load.levelDone == true)
        {
            timeStart = false;
        }
    }

    //calculates how many stars based on time, in order of best time to worst
    //all star variables have to be manually set based on expected time to complete the level
    //floats are a nightmare so just add 1 to the time you want
    //eg. 3 stars takes 30 secs -> put 31 secs in field
    public void playerPoints()
    {
        Debug.Log(currentTime);
        if(currentTime <= threeStar)
        {
            threeWin.SetActive(true);
            twoWin.SetActive(true);
            oneWin.SetActive(true);
        }
        else if(currentTime > threeStar && currentTime <= twoStar)
        {
            twoWin.SetActive(true);
            oneWin.SetActive(true);
        }
        else if(currentTime > twoStar && currentTime <= oneStar)
        {
            oneWin.SetActive(true);
        }
    }

    public void DisplayTime(TextMeshProUGUI winTime)
    {
        TimeSpan niceTime = TimeSpan.FromSeconds(currentTime);
        winTime.SetText("Your time: " + niceTime.ToString(@"mm\:ss"));
    }
}
