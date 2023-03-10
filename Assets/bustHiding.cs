using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bustHiding : MonoBehaviour
{
    public GameObject playerObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //run sleeping animation
            //gameObject.layer uses only integers, but we can turn a layer name into a layer integer using LayerMask.NameToLayer()
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Undetectable");
            playerObj.layer = LayerIgnoreRaycast;
            Debug.Log("Current layer: " + playerObj.layer);
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int LayerEnableRaycast = LayerMask.NameToLayer("Player");
            playerObj.layer = LayerEnableRaycast;
            Debug.Log("Current layer: " + playerObj.layer);
        }
    }
}
