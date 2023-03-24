using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyVision : MonoBehaviour
{
    //[SerializeField] private float enemSpeed;
    //[SerializeField] private float enemRange;
    float startBound;
    float direction = 1f;
    private int sceneNum;

    [SerializeField] private PolygonCollider2D lightCollider;
    [SerializeField] private LayerMask layer1;
    [SerializeField] private float detectionDist;
    bool detectable;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] GameObject warning;
    
    GameObject dot;
    public static Vector2 checkpoint;
    [SerializeField] playerMove player;
    //Transform enemy;

    float timeLeft = 3.0f;
    void Start()
    {
        startBound = transform.position.x;
        //enemy = gameObject.transform.parent;
        //sceneNum = SceneManager.GetActiveScene().buildIndex;
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

    private void CreateWarning()
    {
        dot = Instantiate(warning, transform.position, transform.rotation);
        //warning.transform.position = new Vector3(enemy.position.x, enemy.position.y + 5.0f, enemy.position.z);
        //warning.transform.SetParent(enemy.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detectable = true;
            Debug.Log("Detected");
            CreateWarning();
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
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //moves player to the last checkpoint they touched
                player.GetComponent<playerMove>().transform.position = checkpoint;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detectable = false;
            Debug.Log("i'm out");
            Destroy(dot);
        }
    }
}
