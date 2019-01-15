using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDeux : MonoBehaviour {

    
    public int index;
    public float score;

    public static GameManagerDeux Instance;
    public GamemanagerScript gameManagerScript;
    public Swipe swipe;

    void Awake()
    {

        Instance = this;

    }

    void Start()
    {
        DataManagerDeux.Instance.Load();

    }

    void Update()
    {
        score = gameManagerScript.score;
        if (swipe.isLevelEnded == true)
        {
            MaterialChangeUpdate();

        }
    }

    private void MaterialChangeUpdate()
    {
        
        // change la méthode pour avoir le score
 
            DataManagerDeux.Instance.Save();
            Debug.Log("value is saved");

    }

    public void OnApplicationPause(bool pause)
    {
        DataManagerDeux.Instance.Save();
    }
}
