using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject runeCollected;
    public SoundHolder soundHolder;
    private AudioSource audioSource;
    public bool havingKey = false;
    void Start()
    {
        // runeCollected = GameObject.Find("RuneCollected");
        runeCollected.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayBonkSound(){
        audioSource.PlayOneShot(soundHolder.bonk);
    }
    public void PlayFoundARuneSound(){
        audioSource.PlayOneShot(soundHolder.foundARune);
    }
}
