using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour
{

    public float speed;
    public bool isPlaneAlive;
    public bool isLevelStarted = false;
    public Component swipeScript;

    public void Start()
    {
        swipeScript = GameObject.Find("Plane").GetComponent<Swipe>();
    }

    void Update()

    {
        
        isLevelStarted = GameObject.Find("Plane").GetComponent<Swipe>().shouldLevelStart;
        isPlaneAlive = GameObject.Find("Plane").GetComponent<Swipe>().planeIsAlive;
        if (isLevelStarted == true)
        {
            if (isPlaneAlive == true)
            {
                transform.position += (new Vector3(0, 0, 1) * Time.deltaTime * speed);
            }
            else
            {
                transform.position += (new Vector3(0, 0, 0) * Time.deltaTime * speed);
            }
        }

    }
}
