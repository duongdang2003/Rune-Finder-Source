using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionZone : MonoBehaviour
{
    public UIHolder canvas;
    public Sprite sprite;
    public string instrustionText;
    public string instructionTitle;
    public bool isOpened = false;
    private void Start() {
        canvas = GameObject.Find("Canvas").GetComponent<UIHolder>();
    }
    private void Update() {
        if(isOpened){
            if(Input.GetKeyDown(KeyCode.Return)){
                canvas.instrustion.GetComponent<Animator>().SetTrigger("Hide");
                Destroy(gameObject);
            }
        }
    }
   private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7){
            canvas.instructionImage.GetComponent<Image>().sprite = sprite;
            canvas.instructionText.GetComponent<Text>().text = instrustionText;
            canvas.instructionTitle.GetComponent<Text>().text = instructionTitle;
            canvas.instrustion.SetActive(true);
            canvas.instrustion.GetComponent<Animator>().SetTrigger("Show");
            Time.timeScale = 0;
            isOpened = true;
        }
    }
    // private void OnTriggerExit2D(Collider2D other) {
    //     if(other.gameObject.layer == 7){
    //         Destroy(gameObject);
    //     }

    // }
}
