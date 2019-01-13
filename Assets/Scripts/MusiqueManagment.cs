using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MusiqueManagment : MonoBehaviour {

    public AudioSource audioSource1;
    public float audioSource1Duration =17.22f;
    public AudioSource audioSource2;

    private void Start()
    {
        StartCoroutine(MusiqueManager());
    }

    IEnumerator MusiqueManager()
    {
        audioSource1.Play();
        yield return new WaitForSeconds(audioSource1Duration);
        audioSource2.Play();
    }
}
