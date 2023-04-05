using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadNextScene : MonoBehaviour
{
    private int sceneNum;
    public bool levelDone;
    [SerializeField] GameObject completed;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] private Timer timer;

    private void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        levelDone = false;
        completed.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //int nextScene = sceneNum + 1;
            //SceneManager.LoadScene(sceneNum + 1);
            levelDone = true;
            completed.SetActive(true);
            timer.playerPoints();
            timer.DisplayTime(timeText);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(sceneNum + 1);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
