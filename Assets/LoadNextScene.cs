using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadNextScene : MonoBehaviour
{
    private int sceneNum;
    public bool levelDone;
    private void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        levelDone = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Scene currentScene = SceneManager.GetActiveScene();

        if(collision.gameObject.tag == "Player")
        {
            int nextScene = sceneNum + 1;
            SceneManager.LoadScene(nextScene);
            levelDone = true;
        }
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
