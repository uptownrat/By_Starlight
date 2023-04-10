using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Color newColor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyVision.checkpoint = transform.position;
            //changes checkpoint color upon touching
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
            Debug.Log("saved");
        }
    }
}
