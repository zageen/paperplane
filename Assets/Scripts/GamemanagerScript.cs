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
    public int pieceCollectee;
    public float coinMultiplier = 50;
    public float specialCoinMultiplier = 200;

    public GameObject pauseUI;
    public GameObject inGameCanvas;




    public Text scoreText;
    public Text endScoreText;
    public float highScore;
    public Text highscoreText;
    public int totalPièce;
    public Text totalPièceText;





    public float scoreMultiplicator;
    public bool isGameStarted;
    private int totalPieceCollectee;

    public DataManagerDeux dataManager;




    void Start()
    {
        highScore = dataManager.highScore;


    }
    private void Awake()
    {
        isGameRunning = true;
        currentSceneID = SceneManager.GetActiveScene().buildIndex;

    }


    void Update()
    {
        isGameStarted = planeModele.GetComponent<Swipe>().shouldLevelStart;

        if (isGameStarted == true)
        {
            pieceCollectee = planeModele.GetComponent<ModelAddForce>().coinCollected;
            score = pieceCollectee * coinMultiplier + score + Time.deltaTime * scoreMultiplicator;
            scoreText.text = endScoreText.text = "score :" + score.ToString();
        }
        totalPièceText.text = "nombre de pièces : " + (totalPièce + pieceCollectee).ToString();
        totalPieceCollectee = pieceCollectee;
        if (score > highScore)
        {
            highScore = score;
        }
        highscoreText.text = "Highscore : " + highScore;
    }

    public void OnClickPause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        inGameCanvas.SetActive(false);
    }

    public void OnclickPlay()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        inGameCanvas.SetActive(true);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }



}
