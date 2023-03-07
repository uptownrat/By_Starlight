using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalInteract : MonoBehaviour
{
    bool canInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract == true && Input.GetKeyDown(KeyCode.Z))
        {
            //turn light on/off
            //is it the light intensity??
        }
    }
}
