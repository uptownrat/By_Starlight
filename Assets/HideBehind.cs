using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehind : MonoBehaviour
{
    bool canInteract;
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
        if (canInteract == true && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("no see");
        }
    }
}
