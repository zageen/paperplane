using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulettePapier : MonoBehaviour {

    public GameObject boulette;

    // Use this for initialization
    void Start()
    {
        boulette.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        boulette.SetActive(true);

    }
}
