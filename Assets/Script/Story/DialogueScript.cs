using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    private Text text;
    public string[] dialogueList;
    private int dialogueListIndex = 0;
    private int dialogueIndex = 0;
    public string currentText = "";
    public GameObject runeGroup, continueLog;
    private bool lockEnter = true;
    public GameObject levelLoader;
    public AudioClip popSound;
    private AudioSource audioSource;
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(DisplayText());
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !lockEnter){
            StartCoroutine(DisplayText());
        }
    }
    IEnumerator DisplayText(){
        lockEnter = true;
        continueLog.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        if(dialogueListIndex < dialogueList.Length){
            if(dialogueIndex < dialogueList[dialogueListIndex].Length){
                currentText += dialogueList[dialogueListIndex][dialogueIndex];
                PlayPopSound();
                text.text = currentText;
                dialogueIndex++;
                StartCoroutine(DisplayText());

            } else {
                currentText = "";
                dialogueListIndex++;
                dialogueIndex = 0;
                lockEnter = false;
        
                if(dialogueListIndex == dialogueList.Length){
                    StartCoroutine(LoadNewLevel());
                } else continueLog.SetActive(true);
            }
            if(dialogueListIndex == 0) runeGroup.SetActive(true);
            else if(dialogueListIndex == 2 && dialogueIndex > 0) runeGroup.GetComponent<Animator>().SetTrigger("Break");

        }
    }
    IEnumerator LoadNewLevel(){
        yield return new WaitForSeconds(1);
        levelLoader.GetComponent<LevelLoader>().loadNewLevel();
    }
    private void PlayPopSound(){
        audioSource.PlayOneShot(popSound);
    }
}
