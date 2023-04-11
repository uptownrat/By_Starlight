using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LvlSelection : MonoBehaviour
{
    //[SerializeField] GameObject level;
    //GameObject[] level1 = GameObject.FindGameObjectsWithTag("level1");
    //GameObject[] level2 = GameObject.FindGameObjectsWithTag("level2");

    public void selectLevel(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}