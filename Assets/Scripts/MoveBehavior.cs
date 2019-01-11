using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour {

    public float speed;


    // c'est ici que va se gérer le movement par le tactile




 
 


    void Update ()
    {
        transform.position += (new Vector3 (0,0,1) * Time.deltaTime * speed);
 
	}
}
