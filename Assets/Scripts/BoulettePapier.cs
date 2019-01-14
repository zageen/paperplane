using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulettePapier : MonoBehaviour {

    public GameObject boulette;
    public GameObject barrier;

    // Use this for initialization
    void Start()
    {
        boulette.GetComponent<MeshRenderer>().enabled = false;
        boulette.GetComponent<MeshCollider>().enabled = false;
        barrier.GetComponent<BoxCollider>().enabled = true;
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        barrier.GetComponent<BoxCollider>().enabled = false;
        boulette.GetComponent<MeshRenderer>().enabled = true;
        boulette.GetComponent<MeshCollider>().enabled = true;

    }
}
