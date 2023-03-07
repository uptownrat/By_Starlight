using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    bool canInteract;
    public GameObject gate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canInteract = true;
            //Debug.Log("i'm in");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = false;
            //Debug.Log("i'm out");
        }
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if(canInteract == true && Input.GetKeyDown(KeyCode.Z))
        {
            //move lever and move door
        }
    }
}
