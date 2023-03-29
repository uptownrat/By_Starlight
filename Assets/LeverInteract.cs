using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : MonoBehaviour
{
    public static int timesInteracted = 0;

    bool canInteract;
    [SerializeField] gate gate, gate2, gate3;
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
        if(canInteract == true && Input.GetKeyDown(KeyCode.E))
        {
            //move lever
            Debug.Log("pressed E on the lever");
            timesInteracted++;
            if(timesInteracted % 2 == 1)
            {
                anim.SetTrigger("onInteract");
            }
            else if(timesInteracted % 2 == 1)
            {
                //insert animation for moving lever back to original position
            }
            //Debug.Log("Lever interacts:" + timesInteracted);

            //moving doors
            gate.MoveGate();
            gate2.MoveGate();
            gate3.MoveGate();
        }
    }
}
