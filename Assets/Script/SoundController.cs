using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
    public SoundHolder soundHolder;
    private void Start() {
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }
    public void PlayWindSound(){
        audioSource.PlayOneShot(soundHolder.windSound);
    }
    public void PlayDashSound(){
        audioSource.PlayOneShot(soundHolder.dashSound);
    }
}
