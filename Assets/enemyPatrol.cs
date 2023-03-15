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

    [SerializeField] private BoxCollider2D detectPlayer;
    [SerializeField] private LayerMask layer1;
    [SerializeField] private float range;
    [SerializeField] private float detectionDist;
    public GameObject playerObj;

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


}
