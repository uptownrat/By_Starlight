using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D col;
    public AudioSource src;
    public AudioClip open, close;

    public bool isOpen; //this has to be manually set for each gate
    //most gates start off closed so it'll be fine

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        src = GetComponent<AudioSource>();
    }

    //only changes the gate animation and adds/destroys collider
    //if the gate starts off open, box collider needs to be unchecked in inspector and isOpen needs to be checked
    public void MoveGate()
    {
        if(gameObject != null) {
            if (isOpen == false)
            {
                anim.SetTrigger("onLeverOn");
                Destroy(col);
                isOpen = true;

                src.clip = open;
                src.Play();
            }
            else if (isOpen == true)
            {
                anim.SetTrigger("onLeverOff");
                col = gameObject.AddComponent<BoxCollider2D>();
                isOpen = false;

                src.clip = close;
                src.Play();
            }
        }
    }
}
