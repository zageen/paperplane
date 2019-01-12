using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBehavior : MonoBehaviour {

    public GameObject plane;
    public GameObject ground;
    private Transform planeTransform;
    private Transform groundTransform;
    public bool isLevelStarted = false;
    public Component swipeScript;


    void Start ()
    {
        planeTransform = plane.transform;
        groundTransform = ground.transform;
        
	}
	
	


	void Update ()
    {
        isLevelStarted = GameObject.Find("Plane").GetComponent<Swipe>().shouldLevelStart;
        if(isLevelStarted == true)
        {
        gameObject.transform.position = new Vector3(plane.transform.position.x, (groundTransform.position.y+0.2f) , plane.transform.position.z);
        }
	}
}
