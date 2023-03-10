using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CrystalInteract : MonoBehaviour
{
    static int timesInteracted = 0;

    bool canInteract;
    public Light2D crystal;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
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
        // turn light on and off
        if (canInteract == true && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("touching");
            if (crystal.intensity == 0)
            {
                crystal.intensity = 1;
            }
            else
            {
                crystal.intensity = 0;
            }
            timesInteracted++;
            Debug.Log(timesInteracted);
        }
    }
}
