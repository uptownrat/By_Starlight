using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField] private float enemSpeed;
    [SerializeField] private float enemRange;
    float startBound;
    int direction = 1;
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
            direction *= -1;
        }
        else if(transform.position.x > startBound + enemRange)
        {
            direction *= -1;
        }
    }
}
