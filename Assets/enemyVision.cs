using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyVision : MonoBehaviour
{
<<<<<<< Updated upstream
    //[SerializeField] private float enemSpeed;
    //[SerializeField] private float enemRange;
    float startBound;
    float direction = 1f;

    [SerializeField] private PolygonCollider2D lightCollider;
    [SerializeField] private LayerMask layer1;
    [SerializeField] private float detectionDist;
    bool detectable;
    [SerializeField] private float speed;
    [SerializeField] private float range;

    float timeLeft = 3.0f;
    void Start()
    {
        startBound = transform.position.x;
=======
    public playerMove player;
    //public GameObject startPoint;
    private int thisScene;
    
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
>>>>>>> Stashed changes
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * direction);
        Vector3 left = new Vector3(0, 0, 0);
        Vector3 right = new Vector3(180, 0, 0);

        if (transform.position.x < startBound)
        {
            direction *= -1f;
            //lightCollider.offset = new Vector2(1, lightCollider.offset.y);
            transform.eulerAngles = left;
        }
        else if (transform.position.x > startBound + range)
        {
            direction *= -1f;
            //lightCollider.offset = new Vector2(-1, lightCollider.offset.y);
            transform.eulerAngles = right;

        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
<<<<<<< Updated upstream
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
=======
            if (player.playerVisible == true)
            {
                Debug.Log("caught");
                //player.transform.position = startPoint.transform.position;
                thisScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(thisScene);
            }
        }
    }
>>>>>>> Stashed changes
}