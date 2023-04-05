using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class worryMeter : MonoBehaviour
{
    public Animator anim;
    
    public int currentWorry = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void onCaught()
    {
        currentWorry = currentWorry + 1;
        anim.SetTrigger("caught");
        Debug.Log("onCaught triggered");

        if (currentWorry == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
