using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worryMeter : MonoBehaviour
{
    public int currentWorry = 0;
    public void onCaught()
    {
        currentWorry = currentWorry + 1;

        switch(currentWorry)
        {
            case 1:
                // switch to slightly worried sprite
                break;
            case 2:
                // switch to worried sprite
                break;
            case 3:
                break;
            default:
                //normal sprite
                break;
        }
    }
}
