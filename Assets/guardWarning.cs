using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class guardWarning : MonoBehaviour
{
    private float time;
    [SerializeField] TextMeshProUGUI text;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void Awake()
    {
        time = 3.0f;
        text.SetText(time.ToString());
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while(time > 0)
        {
            time--;
            //text.SetText(time.ToString());
            Debug.Log("fuck " + time);
        }
        yield return new WaitForSeconds(1);
    }

}
