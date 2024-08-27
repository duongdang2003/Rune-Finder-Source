using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectorScript : MonoBehaviour
{
    public bool currentButton, isStartedGame = false;
    public GameObject startButton, quitButton;
    void Start()
    {
        startButton = GameObject.Find("Start").GetComponentsInChildren<RectTransform>()[1].gameObject;
        quitButton = GameObject.Find("Quit").GetComponentsInChildren<RectTransform>()[1].gameObject;

        currentButton = true;
        SelectButton();
        isStartedGame = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || 
        Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)){
            currentButton = !currentButton;
            SelectButton();
        }
        if(Input.GetKeyDown(KeyCode.Return) && currentButton){
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().loadNewLevel();
        }
    }
    private void SelectButton(){
        if (currentButton == true)
        {
            startButton.GetComponent<Text>().color = new Color(0.8588235f, 0.8588235f, 0.8588235f, 1);
            quitButton.GetComponent<Text>().color = new Color(0.6037736f, 0.6037736f, 0.6037736f, 1);
        } else {
            quitButton.GetComponent<Text>().color = new Color(0.8588235f, 0.8588235f, 0.8588235f, 1);
            startButton.GetComponent<Text>().color = new Color(0.6037736f, 0.6037736f, 0.6037736f, 1);
        }
        if(isStartedGame)
        GetComponent<AudioSource>().Play();
    }
}
