using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MusiqueManagment : MonoBehaviour {

    public AudioSource audioSource1;
    public float audioSource1Duration =17.22f;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    [SerializeField] private bool isLevelEnded = GameObject.Find("Plane").GetComponent<Swipe>().isLevelEnded;

    private void Start()
    {
        StartCoroutine(MusiqueManager());
    }

    private void Update()
    {
        if(isLevelEnded == true)
        {
            audioSource3.Play();
        }
        
    }

    IEnumerator MusiqueManager()
    {
        audioSource1.Play();
        yield return new WaitForSeconds(audioSource1Duration);
        audioSource2.Play();
       
    }
    IEnumerator EndMusique()
    {
        audioSource3.Play();
        yield return null;
    }
}
