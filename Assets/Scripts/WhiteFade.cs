using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // add to the top

public class WhiteFade : MonoBehaviour
{




    public CanvasGroup myCG;
    public float speed;
    public bool flash = false;

    void Update()
    {
        if (flash == true)
        {

            myCG.alpha = myCG.alpha +  Time.deltaTime * speed;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Player")
        {
            flash = true;
        }
    }
}
