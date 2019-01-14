using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // add to the top

public class WhiteFade : MonoBehaviour
{




    public CanvasGroup myCG;
    public float speed;


    private bool flash = true;

    void Update()
    {
        if (flash == true)
        {

            myCG.alpha = myCG.alpha +  Time.deltaTime * speed;
            
        }
    }

}
