using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField] private float enemSpeed;
    [SerializeField] private float enemRange;
    private SpriteRenderer Srenderer;
    float startBound;
    int direction = 1;

    //[SerializeField] private BoxCollider2D detectPlayer;
    [SerializeField] private LayerMask layer1;
    [SerializeField] private float range;
    [SerializeField] private float detectionDist;
    public GameObject playerObj;
    bool canInteract;

    float timeLeft = 2.0f;

    void Start()
    {
        startBound = transform.position.x;
        Srenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        transform.Translate(Vector2.left * enemSpeed * Time.deltaTime * direction);
        Vector3 right = new Vector3(0, 0, 0);
        Vector3 left = new Vector3(0, 180, 0);

        if (transform.position.x < startBound)
        {
            direction *= -1;
            transform.eulerAngles = left;
            //knightCollider.offset = new Vector2(1, knightCollider.offset.y);

        }
        else if(transform.position.x > startBound + enemRange)
        {
            direction *= -1;
            transform.eulerAngles = right;
            //knightCollider.offset = new Vector2(-1, knightCollider.offset.y);

        }
    }

    //private bool playerCaught()
    //{
    //    RaycastHit2D found = Physics2D.BoxCast(detectPlayer.bounds.center + transform.right * range * direction * detectionDist,
    //        new Vector3(detectPlayer.bounds.size.x * range, detectPlayer.bounds.size.y, detectPlayer.bounds.size.z),
    //        0, Vector2.left, 0, layer1);

    //    return found.collider != null;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
            Debug.Log("ready 4 sleep");
        }
        sleepingSpell();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
            Debug.Log("safe");
        }
    }

    private void sleepingSpell()
    {
        if (canInteract == true && Input.GetKeyDown(KeyCode.X)) //change to hold z later when working
        {
            Debug.Log("sleeping");
            //run sleeping animation
            //gameObject.layer uses only integers, but we can turn a layer name into a layer integer using LayerMask.NameToLayer()
            int LayerIgnoreRaycast = LayerMask.NameToLayer("enemySleeping");
            playerObj.layer = LayerIgnoreRaycast;
            Debug.Log("Current layer: " + playerObj.layer);
        }
        else
        {
            int LayerEnableRaycast = LayerMask.NameToLayer("Player");
            playerObj.layer = LayerEnableRaycast;
            Debug.Log("Current layer: " + playerObj.layer);
        }
    }
}

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Player")
         {
             detectable = true;
             Debug.Log("Detected");

         }
     }

     private void OnTriggerStay2D(Collider2D collision)
     {
         if (detectable == true)
         {
             timeLeft -= Time.deltaTime;
             if (timeLeft < 0)
             {
                 Debug.Log("You lose");
             }

         }

     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Player")
         {
             detectable = false;
             Debug.Log("i'm out");
         }
     }*/

