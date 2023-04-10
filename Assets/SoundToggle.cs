using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    //private bool isMusic;
    //[SerializeField] Image musicImg;
    //[SerializeField] Sprite musicOff, musicOn;
    // Start is called before the first frame update
    void Start()
    {
        //isMusic = gameObject.GetComponent<Toggle>().isOn;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MuteMusic()
    {
        if(AudioListener.volume == 1)
        {
            //isMusic = false;
            AudioListener.volume = 0;
            //musicImg.sprite = musicOn;
        }
        else
        {
            //isMusic = true;
            AudioListener.volume = 1;
            //musicImg.sprite = musicOff;
        }
    }
}
