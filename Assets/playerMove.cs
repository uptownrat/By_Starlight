using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    int doubleJump;
    bool resetJumps;
    private Rigidbody2D rbody;
   
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(resetJumps == true || doubleJump < 2)
        {
            /*if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
            {
                //rigidbody.velocity = new Vector3(0, 5, 0);
            Vector2 jump = new Vector2(rigidbody.velocity.x, );
            */
            
            if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
            {
                rbody.velocity = new Vector2(rbody.velocity.x, 7);
                doubleJump++;
            }
        //}
        }
        else if (resetJumps == false && doubleJump > 2)
        {
            if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
            {
                rbody.velocity = new Vector2(rbody.velocity.x, 0);
            }
            doubleJump = 0;
        }

        rbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            resetJumps = true;
            doubleJump = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            resetJumps = false;
        }
    }
}
