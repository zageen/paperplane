using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehavior : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {

            Destroy(this.gameObject);
           
        
    }
}
