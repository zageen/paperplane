using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraMoveBehavior : MonoBehaviour {

    public Animator anim;
    public float speed;
    public bool isPlaneAlive;
    public bool isLevelStarted = false;
    public bool isPlaneAnimStarted = false;
    public Component swipeScript;
    public Transform planeTransform;



    void Update()
    {
        anim = GetComponent<Animator>();
        isPlaneAnimStarted = GameObject.Find("Plane").GetComponent<Swipe>().isPlaneAnimationStarted;
        isLevelStarted = GameObject.Find("Plane").GetComponent<Swipe>().shouldLevelStart;
        isPlaneAlive = GameObject.Find("Plane").GetComponent<Swipe>().planeIsAlive;
        if(isPlaneAnimStarted == true && isLevelStarted != true)
        {
            anim.Play("CameraStartAnimation");
        }
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

    void DestroyAnimator()
    {
        StartCoroutine(TimeToDeactivateAnimator());
    }

    IEnumerator TimeToDeactivateAnimator()
    {
        yield return new WaitForSeconds(0.001f);
        anim.enabled = false;
    }
}

