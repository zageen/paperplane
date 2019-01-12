using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsorBehavior : MonoBehaviour {

    private Rigidbody player;
    public float xAxisForce;
    public float yAxisForce;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.AddForce(new Vector3(xAxisForce, yAxisForce, 0));
        }
    }

}
