using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject Plane;
    public Rigidbody rb;
    public GameObject PlaneModele;

    public float swipeDistanceThreshold = 150;

    public float dragTime;
    public float maxDragTime = 0.5f;


    public float forceMultiplier = 5;
    public float rotationSpeed;

    public float specialCollectibleCollected;
    public float coinCollected;


    private Vector2 currentPosition;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector3 currentSwipe;
    Vector3 swipeVector;

    private bool isDraging = false;
    public AnimationCurve animationCurve;

    private float actualTime;
    private float totalTime;
    private Quaternion firstRotation;

    public void Start()
    {

    }


    private void Update()
    {

        dragTime = dragTime + Time.deltaTime;
        #region Keyboardcontrol

        if (Input.GetKey(KeyCode.UpArrow))
        {
            swipeVector = Vector3.up;
            isDraging = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            swipeVector = Vector3.left;
            isDraging = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            swipeVector = Vector3.right;
            isDraging = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            swipeVector = Vector3.down;
            isDraging = true;
        }
        else
        {
            isDraging = false;
            totalTime = PlaneModele.transform.rotation.eulerAngles.sqrMagnitude / (rotationSpeed * 25000f);
            firstRotation = PlaneModele.transform.rotation;
            actualTime = 0f;
        }

        #endregion



        #region phone controle
        if (Input.touchCount == 1)
        {

            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // stockage du point de départ
                    secondPressPos = touch.position;
                    firstPressPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    // stockage du point de fin
                    isDraging = true;
                    secondPressPos = touch.position;
                    if (dragTime > maxDragTime)
                    {
                        isDraging = false;
                        dragTime = 0;
                    }
                    break;
                case TouchPhase.Ended:
                    isDraging = false;
                    totalTime = PlaneModele.transform.rotation.eulerAngles.sqrMagnitude / (rotationSpeed * 50f);
                    firstRotation = PlaneModele.transform.rotation;
                    actualTime = 0f;
                    break;

            }
        }

        swipeVector = new Vector3((secondPressPos.x - firstPressPos.x), secondPressPos.y - firstPressPos.y, 0);//determine le vecteur que l'avion va prendre 
        #endregion

        if (isDraging == true)
        {
            //direction de l'avion
            rb.AddForce(swipeVector * forceMultiplier);
            #region rotateplane
            if (swipeVector.x > 0)
            {
                PlaneModele.transform.Rotate(new Vector3(0, 0, -1) * rotationSpeed);
            }
            else if (swipeVector.x < 0)
            {
                PlaneModele.transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed); ;
            }
            if (swipeVector.y > 0)
            {
                PlaneModele.transform.Rotate(new Vector3(-1, 0, 0) * rotationSpeed); ;
            }
            else if (swipeVector.y < 0)
            {
                PlaneModele.transform.Rotate(new Vector3(1,0,0) * rotationSpeed); ;
            }

        }
        if (isDraging == false)
        {
            actualTime += Time.deltaTime;
            PlaneModele.transform.rotation = Quaternion.Lerp(firstRotation, Quaternion.identity, actualTime / totalTime);
        }

        #endregion
        //si la personne prend trop de temps
        if (dragTime > maxDragTime)
        {
            isDraging = false;

        }


    }

}

