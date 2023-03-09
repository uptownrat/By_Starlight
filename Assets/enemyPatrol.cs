using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField] private float enemSpeed;
    [SerializeField] private float enemRange;
    float startBound;
    float direction = 1f;

    [SerializeField] private BoxCollider2D detectPlayer;
    [SerializeField] private LayerMask layer1;
    [SerializeField] private float range;
    [SerializeField] private float detectionDist;
    bool detectable;

    public GameObject DetectionRay;
    [SerializeField] float rayDistance;
    float timeLeft = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        startBound = transform.position.x;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * enemSpeed * Time.deltaTime * direction);

        if(transform.position.x < startBound)
        {
            direction *= -1f;
            detectPlayer.offset = new Vector2(1, detectPlayer.offset.y);

        }
        else if(transform.position.x > startBound + enemRange)
        {
            direction *= -1f;
            detectPlayer.offset = new Vector2(-1, detectPlayer.offset.y);

        }

        /*if (playerCaught())
        {
            //timeLeft -= Time.deltaTime;
            Debug.Log("Caught");
            if (timeLeft < 0)
            {
                timeLeft = 0;
                Debug.Log("You lose");

            }
        }*/


        //detectPlayer.GetComponent<BoxCollider2D>().offset = new Vector2(newX, newY);
        //detectPlayer.offset = new Vector2(detectPlayer.offset.x * direction, detectPlayer.offset.y);
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
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
    }

    void FixedUpdate()
    {

        /*RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layer1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }*/
        //detectingPlayer();

    }
      /*  private bool playerCaught()
    {
        RaycastHit2D found =
            Physics2D.BoxCast(detectPlayer.bounds.center + transform.right * range * direction * detectionDist,
            new Vector2(detectPlayer.bounds.size.x * range, detectPlayer.bounds.size.y),
            0f, Vector2.left, 0f, layer1);
        //Debug.Log("Hello");

        if (found.collider != null)
        {
            Debug.Log("Hello");
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(detectPlayer.bounds.center + transform.right * range * direction * detectionDist,
               new Vector2(detectPlayer.bounds.size.x * range, detectPlayer.bounds.size.y));
        }

        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(detectPlayer.bounds.center + transform.right * range * direction * detectionDist,
               new Vector2(detectPlayer.bounds.size.x * range, detectPlayer.bounds.size.y));
        }
        return found.collider != null;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(detectPlayer.bounds.center + transform.right * range * direction * detectionDist,
           new Vector2(detectPlayer.bounds.size.x * range, detectPlayer.bounds.size.y));

    }*/

    /*

    private void detectingPlayer()
    {
        //detectPlayer.bounds.center + transform.right * range * direction * detectionDist,
         //   new Vector2(detectPlayer.bounds.size.x * range, detectPlayer.bounds.size.y)
        RaycastHit2D playerFound = Physics2D.Raycast(DetectionRay.transform.position * direction,
             Vector2.right * direction, rayDistance, layer1);

        if (playerFound.collider != null)
        {
            Debug.Log("Player Found");
            Debug.DrawRay(DetectionRay.transform.position * direction, Vector2.right * playerFound.distance * direction, Color.red);

        }

        else
        {
            Debug.Log("Player safe");
            Debug.DrawRay(DetectionRay.transform.position * direction, Vector2.right * playerFound.distance * direction, Color.green);

        }
    }*/

}
