using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLvlScript : MonoBehaviour
{
    public void loadLevel1()
    {
        SceneManager.LoadScene("Level 1 (Beta)", LoadSceneMode.Single);
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene("Level 2 (Beta)", LoadSceneMode.Single);
    }
}
