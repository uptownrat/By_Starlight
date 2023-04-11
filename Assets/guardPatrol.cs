using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rigidB;
    private Transform currPoint;
    public float speed;
    public float visDir;
    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        currPoint = pointB.transform;
        flipSprite();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currPoint.position - transform.position;

        if(currPoint == pointB.transform)
        {
            //Debug.Log("hit b");
            rigidB.velocity = new Vector2(speed, 0);
        }
        else
        {
            //Debug.Log("hit a");

            rigidB.velocity = new Vector2(-speed, 0);
        }

       if(Vector2.Distance(transform.position, currPoint.position) < 0.5f && currPoint == pointB.transform)
        {
            flipSprite();
            visDir = -1;
            currPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currPoint.position) < 0.5f && currPoint == pointA.transform)
        {
            flipSprite();
            visDir = 1;
            currPoint = pointB.transform;
        }
        //Debug.Log(currPoint.name);

    }

    private void flipSprite()
    {
        Vector3 flipping = transform.localScale;
        flipping.x *= -1;
        transform.localScale = flipping;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);

    }
}

