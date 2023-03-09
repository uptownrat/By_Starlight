using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }
}
