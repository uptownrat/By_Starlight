using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : MonoBehaviour
{
    static int timesInteracted = 0;

    bool canInteract;
    public gate gate;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
            Debug.Log("i'm in");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
            Debug.Log("i'm out");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract == true && Input.GetKeyDown(KeyCode.X))
        {
            //move lever and move door
            Debug.Log("pressed X on the lever");
            anim.SetTrigger("onInteract");
            gate.anim.SetTrigger("onLeverFlip");
            Destroy(gate.col);
            timesInteracted++;
        }
    }
}
