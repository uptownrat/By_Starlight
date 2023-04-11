using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    int doubleJump;
    bool resetJumps;
    private Rigidbody2D rbody;
    public bool playerVisible;

    public AudioSource src;
    public AudioClip walk;

    public Animator princeMove;

    bool jumpActive;
    bool notMoving;
    bool left;
    bool right;
   
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();

        playerVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        jumpActive = false;
        notMoving = true;
        left = false;
        right = false;

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

                jumpActive = true;
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

        if (rbody.velocity.x < 0 && jumpActive == false) 
        { 
            left = true;
            right = false;
            notMoving = false;
        }
		else if (rbody.velocity.x > 0 && jumpActive == false)
		{
			right = true;
            left = false;
			notMoving = false;
		}

		if (rbody.velocity.x != 0 && resetJumps == true && src.isPlaying == false)
        {
            src.clip = walk;
            src.Play();
        }
        else if (resetJumps == false)
        {
            src.Stop();
        }

		princeMove.SetBool("isJumping", jumpActive);
		princeMove.SetBool("Still", notMoving);
		princeMove.SetBool("goingLeft", left);
		princeMove.SetBool("goingRight", right);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            resetJumps = true;
            //doubleJump = 0;

            jumpActive = false;
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
