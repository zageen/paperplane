using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : MonoBehaviour {

	void Start ()
    {
		
	}

	void Update ()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody )
            other.attachedRigidbody.AddForce(Vector3.right * 10);
    }
}
