using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingRotation : MonoBehaviour {

    public float speed;

	void Update ()
    {
        gameObject.transform.Rotate(new Vector3(0,0,speed*Time.deltaTime*100));
	}
}
