using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class introSequence : MonoBehaviour
{
    public TMP_Text text1, text2, text3, text4;

    // Start is called before the first frame update
    void Start()
    {
        text1.enabled = true;
        text2.enabled = false;
        text3.enabled = false;
        text4.enabled = false;
    }

    public void nextText()
    {
        if (text1.enabled == true)
        {
            text1.enabled = false;
            text2.enabled = true;
        }
        else if (text2.enabled == true)
        {
            text2.enabled = false;
            text3.enabled = true;
        }
        else if (text3.enabled == true)
        {
            text3.enabled = false;
            text4.enabled = true;
        }
        else
        {
            SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
        }
    }
}
