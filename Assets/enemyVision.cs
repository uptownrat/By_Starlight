using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public static Vector2 checkpoint;
    [SerializeField] playerMove player;

    //vars for guard warning
    [SerializeField] GameObject warning;
    private GameObject dot;
    [SerializeField] GameObject enemy;

    public worryMeter worry;

    float timeLeft = 3.0f;
    void Start()
    {
        startBound = transform.position.x;
        //dotText = enemy.gameObject.transform.GetChild(0).GetChild(0);
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

    ////coroutine for counting down warning
    //private IEnumerator WarningChange()
    //{
    //    while (timeLeft > 0)
    //    {
    //        fill.fillAmount = fill.fillAmount - 0.33f;
    //        yield return new WaitForSeconds(1f);
    //        Debug.Log(timeLeft);
    //    }
    //}

    //created warning that counts down from 3, follows the guard it's assigned to
    private void CreateWarning()
    {
        Transform enTransform = enemy.GetComponent<Transform>();
        dot = Instantiate(warning, enTransform.position, enTransform.rotation);
        dot.transform.position = new Vector3(enTransform.position.x, enTransform.position.y + 1.5f, enTransform.position.z);
        dot.transform.SetParent(enTransform);
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
                timeLeft = 3.0f;
                worry.onCaught();
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
