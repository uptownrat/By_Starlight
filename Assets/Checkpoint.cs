using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Color newColor;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyVision.checkpoint = transform.position;
            //changes checkpoint color upon touching
            // gameObject.GetComponent<SpriteRenderer>().color = newColor;
            anim.SetTrigger("onEnter");
            Debug.Log("saved");
        }
    }
}
