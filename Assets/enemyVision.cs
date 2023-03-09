using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyVision : MonoBehaviour
{
    GameObject player;
    public GameObject startPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //returns player to starting point if caught by guard
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("caught");
            player.transform.position = startPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
