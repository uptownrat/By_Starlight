using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalInteract : MonoBehaviour
{
    bool canInteract;
    public Light crystal;

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
        // turn light on and off
        if (canInteract == true && Input.GetKeyDown(KeyCode.Z))
        {
            if(crystal.intensity == 0)
            {
                crystal.intensity = 1;
            }
            else
            {
                crystal.intensity = 0;
            }
        }
    }
}
