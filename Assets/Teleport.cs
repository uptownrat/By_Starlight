using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    //public static int timesInteracted = 0;

    [SerializeField] GameObject destination;
    [SerializeField] Color newColor;
    bool canInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("im in");
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("im out");
            canInteract = false;
        }
    }

    void Start()
    {
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("teleport");
            GameObject.FindGameObjectWithTag("Player").transform.position = destination.transform.position;
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
            //timesInteracted++;
            //Debug.Log("Tele interacts:" + timesInteracted);
        }
    }
}
