using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject healthContainer;
    private RectTransform[] childrent;
    private bool isTakingDamage = false, isImmortal = false;
    public Rigidbody2D rb;

    public Vector2 knockBackDirection;

    private float KnockBackForce = 2;
    private PlayerMovement playerMovement;
    void Start()
    {
        childrent = healthContainer.GetComponentsInChildren<RectTransform>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isTakingDamage)
        {
            playerMovement.lockMovement = true;
            rb.AddForce(knockBackDirection * KnockBackForce, ForceMode2D.Impulse);
        }
    }
    public void UpdateHealth(int health){
        for (int i = 1; i < childrent.Length; i++){
            if(i > health){
                childrent[i].gameObject.SetActive(false);
            } else {
                childrent[i].gameObject.SetActive(true);
            }
        }
    }
    public void TakeDamage(GameObject source){
        if(!isImmortal){
            health--;
            UpdateHealth(health);
            if(health <= 0){
                RestartGame();
            } else {
                KnockBack(source);
            }
        }
        
    }
    private void KnockBack(GameObject source){
        knockBackDirection = (transform.position - source.transform.position).normalized;
        isTakingDamage = true;
        isImmortal = true;
        GetComponent<Animator>().SetTrigger("TakeDamage");
        StartCoroutine(StopKnockBack());
        StartCoroutine(EndImmortal());
    }
    public void KnockBack(GameObject source, bool isDamaged){
        knockBackDirection = (transform.position - source.transform.position);
        knockBackDirection = (new Vector2(-knockBackDirection.x, knockBackDirection.y)).normalized;
        isTakingDamage = true;
        GetComponent<Animator>().SetTrigger("TakeDamage");
        StartCoroutine(StopKnockBack());
        StartCoroutine(EndImmortal());
    }
    IEnumerator StopKnockBack(){
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector2(0, 0);
        isTakingDamage = false;
        playerMovement.lockMovement = false;
    }
    IEnumerator EndImmortal(){
        yield return new WaitForSeconds(3);

        isImmortal = false;
        GetComponent<Animator>().SetTrigger("Idle");
    }
    public void Death(){
        health = 0;
        UpdateHealth(health);
        RestartGame();
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
