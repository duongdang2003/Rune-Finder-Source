using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuSoudn : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip weeSound;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayWeeSound(){
        audioSource.PlayOneShot(weeSound);
    }
}
