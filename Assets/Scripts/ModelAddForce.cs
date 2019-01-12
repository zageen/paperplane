using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAddForce : MonoBehaviour {

    //gère la force constante vers le bas que subit l'avion

    public Rigidbody rb;
    [Range(0f,0.1f)]
    public float smothingforce;
    [Range(0f, 1f)]
    public float startJumpingForce;
    private bool isPlaneAlive;
    public float coinCollected;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 1, 0) * startJumpingForce);
    }

    void Update ()
    {
        isPlaneAlive = GameObject.Find("Plane").GetComponent<Swipe>().planeIsAlive;
        if (isPlaneAlive == true)
        {
            rb.AddForce(new Vector3(0, 1, 0) * smothingforce);
        }
        
        
    }
    

    //gère le ramassage de pièce
    public void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Coin")
        {
            coinCollected++;
        }
        
    }
}
