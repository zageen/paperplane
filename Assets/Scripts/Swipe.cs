using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Swipe : MonoBehaviour
{
    #region variables
    public GameObject Plane;
    public GameObject gameManager;
    public Rigidbody rb;
    public GameObject PlaneModele;
    public MeshCollider meshCollider;

    public Text yourScore;
    public float score;
    public Text highScoreText;
    public float highScore;
    public bool planeIsAlive;
    public bool shouldLevelStart = false;
    public bool isPlaneAnimationStarted = false;
    public bool isLevelEnded = false;
    public bool planeIsDead = false;


    private Animator anim;


    public float dragTime;
    public float maxDragTime = 0.5f;
    public float timeToSwitchToMenu = 6;


    public float forceMultiplier = 5;
    public float rotationSpeed;
    public float returnInOrginialRotationSpeed;

    public float coinCollected;

    private float timeStockValue;
    public float timeToStartLevel = 9;
    public float actualTimeToStartLevel = 0;

    public Text debugactualTimeToStartLevel;
    public Text debugswipeVectorX;
    public Text debugswipeVectorY;

    private Vector2 currentPosition;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector3 currentSwipe;
    Vector3 swipeVector;

    private bool isDraging = false;

    private float actualTime;
    private float totalTime;
    private Quaternion firstRotation;
    #endregion 

    public void Start()
    {

        planeIsAlive = true;
        anim = GetComponent<Animator>();
        meshCollider.enabled = false;
    }

    void Update()
    {
        score = gameManager.GetComponent<GamemanagerScript>().score;
        
        actualTimeToStartLevel = actualTimeToStartLevel + Time.deltaTime;
        if (Input.touchCount == 1 && shouldLevelStart == false)
        {

            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstPressPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    secondPressPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    firstPressPos = touch.position;
                    secondPressPos = touch.position;
                    break;
            }
            swipeVector = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y, 0);//determine le vecteur que l'avion va prendre 
            if(swipeVector.x>0 && swipeVector.y>0)
            {
                anim.Play("PlaneStartAnimation");
                isPlaneAnimationStarted= true;


}
        }
        if (actualTimeToStartLevel >timeToStartLevel&& shouldLevelStart == false)
        {
            anim.Play("PlaneStartAnimation");
            isPlaneAnimationStarted = true;
        }
        if ( shouldLevelStart == true)
        {
            meshCollider.enabled = true;
            timeStockValue += Time.deltaTime;
            dragTime = dragTime + Time.deltaTime;

            #region phone controle
            if (planeIsAlive == true)
            {


                if (Input.touchCount == 1)
                {

                    var touch = Input.touches[0];
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            // stockage du point de départ
                            secondPressPos = touch.position;
                            firstPressPos = touch.position;
                            dragTime = 0;

                            break;
                        case TouchPhase.Moved:
                            // stockage du point de fin
                            isDraging = true;

                            secondPressPos = touch.position;
                            Debug.Log(firstPressPos);
                            Debug.Log(secondPressPos);
                            if (dragTime > maxDragTime)
                            {
                                isDraging = false;
                                dragTime = 0;

                            }
                            //si la personne prend trop de temps

                            break;
                        case TouchPhase.Ended:
                            isDraging = false;
                            secondPressPos = touch.position;
                            firstPressPos = touch.position;
                            totalTime = PlaneModele.transform.rotation.eulerAngles.sqrMagnitude / (rotationSpeed * returnInOrginialRotationSpeed * 10000f);
                            firstRotation = PlaneModele.transform.rotation;
                            actualTime = 0f;
                            timeStockValue = 0;
                            break;

                    }
                }



            }



            swipeVector = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y, 0);//determine le vecteur que l'avion va prendre 

            swipeVector.Normalize();
            #endregion

            if (isDraging == true)
            {

                //direction de l'avion
                rb.AddForce(swipeVector * forceMultiplier, ForceMode.VelocityChange);
                #region rotateplane
                if (swipeVector.x > 0)
                {
                    PlaneModele.transform.Rotate(new Vector3(0, 0, -2) * rotationSpeed);
                }
                else if (swipeVector.x < 0)
                {
                    PlaneModele.transform.Rotate(new Vector3(0, 0, 2) * rotationSpeed); ;
                }
                if (swipeVector.y > 0)
                {
                    PlaneModele.transform.Rotate(new Vector3(-1, 0, 0) * rotationSpeed); ;
                }
                else if (swipeVector.y < 0)
                {
                    PlaneModele.transform.Rotate(new Vector3(1, 0, 0) * rotationSpeed); ;
                }

            }

            if (isDraging == false)
            {
                actualTime += Time.deltaTime;
                PlaneModele.transform.rotation = Quaternion.Lerp(firstRotation, Quaternion.identity, (actualTime / totalTime) * 4);
            }
        }
        
    }

    #endregion


    void OnCollisionEnter(Collision other)
    {
        if (Time.timeSinceLevelLoad > timeToStartLevel || Input.touchCount==1)
        {
            if (other.gameObject.tag != "Player" && other.gameObject.tag != "Repulsor" && other.gameObject.tag != "Coin" && other.gameObject.tag != "Collectible" && other.gameObject.tag != "LevelEnd")
            {
                planeIsAlive = false;
                swipeVector = Vector3.zero;
                planeIsDead = true;
            }
        }
    }

    void AfterAnimation()
    {
        shouldLevelStart = true;
    }

    void DeactivateAnimator()
    {
        StartCoroutine(TimeToDeactivateAnimator());
    }

    IEnumerator TimeToDeactivateAnimator()
    {
        yield return new WaitForSeconds(0.001f);
        anim.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LevelEnd")
        {
            StartCoroutine(LevelEnd());
        }
    }

    IEnumerator LevelEnd()
    {
        //sauvegarder score ici
        shouldLevelStart = false;
        isLevelEnded = true;
        //charger ici le highScore =
        yourScore.text = "your score is: " + score;
        highScoreText.text = "Highscore : " +highScore;
        yield return new WaitForSeconds(timeToSwitchToMenu);

        SceneManager.LoadScene(0);
    }
}



