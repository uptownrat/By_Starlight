using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destination;
    bool canInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract == true && Input.GetKeyDown(KeyCode.Z))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = destination.transform.position;

        }
    }
}
