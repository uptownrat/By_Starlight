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

    [SerializeField] float threeStar, twoStar, oneStar, noStar;
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
        //stops timer when level is completed
        if (load.levelDone == true)
        {
            timeStart = false;
        }
    }

    void StopTimer()
    {

    }

    //calculates how many stars based on time
    //all star variables have to be manually set based on expected time to complete the level
    void playerPoints()
    {
        if(currentTime <= threeStar)
        {
            //3 stars
        }
        else if(currentTime > threeStar && currentTime <= twoStar)
        {
            //2 stars
        }
        else if(currentTime > twoStar && currentTime <= oneStar)
        {
            //1 star
        }
        else if(currentTime > oneStar)
        {
            //skill issue
        }
    }
}
