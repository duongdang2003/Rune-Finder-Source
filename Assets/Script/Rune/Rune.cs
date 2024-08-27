using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rune : MonoBehaviour
{
    private void Start() {
        StartCoroutine(ChangeDirect());
    }
    private float floatLenght = 0.005f;
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + floatLenght);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7){
            other.gameObject.GetComponent<PlayerRuneCollection>().AddRune(gameObject.name);

            Image displayRune = other.gameObject.GetComponent<PlayerData>().runeCollected.
            GetComponentsInChildren<RectTransform>()[1].gameObject.
            GetComponent<Image>();
            displayRune.SetNativeSize();

            displayRune.sprite = GetComponent<SpriteRenderer>().sprite;
            other.gameObject.GetComponent<PlayerData>().runeCollected.SetActive(true);

            GameObject.Find("Player").GetComponent<PlayerData>().PlayFoundARuneSound();
            Destroy(gameObject);
        }    
    }
    IEnumerator ChangeDirect(){
        yield return new WaitForSeconds(2f);

        floatLenght *= -1;
        StartCoroutine(ChangeDirect());
    }
}
