using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamemanagerScript : MonoBehaviour {


    // gère toute les scènes et la vie du joueur + scoring , sauvegarde du scoring.

    public int playerLife = 3;
   
    public bool isGameRunning;
    public int currentSceneID;
    public GameObject player;
    public bool currentState = true;


    public GameObject planeModele;
    public float specialCollectibleCollected;
    public float score = 0;
    public float pieceCollectee;
    public float coinMultiplier = 50;
    public float specialCoinMultiplier = 200;
    public Text scoreText;
    public float scoreMultiplicator;
    public bool isGameStarted;
    



    void Start ()
    {
        
        isGameRunning = true;
        currentSceneID = SceneManager.GetActiveScene().buildIndex;
        

    }
	

	void Update ()
    {
        isGameStarted = planeModele.GetComponent<Swipe>().shouldLevelStart;

        if (isGameStarted == true)
        {
            pieceCollectee = planeModele.GetComponent<ModelAddForce>().coinCollected;
            score = pieceCollectee * coinMultiplier  + Time.deltaTime * scoreMultiplicator;
            scoreText.text = "score :" + score.ToString();
        }
	}
 
   
}
