using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : EnemyScript
{
    private Rigidbody2D rb;
    public float speed = 1, timeChangeDirection = 2;
    private float direct = -1;
    private bool isDeath = false, canAttack = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirection());
    }

    private void FixedUpdate() {
        if(!isDeath)
        rb.velocity = new Vector2(speed * direct, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 7 && canAttack){
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(gameObject);
            canAttack = false;
            StartCoroutine(UnlockAttack());
        }
    }
    private void Flip(){
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    IEnumerator ChangeDirection(){
        yield return new WaitForSeconds(timeChangeDirection);
        direct *= -1;
        Flip();
        StartCoroutine(ChangeDirection());
    }
    public override void Death(){
        speed = 0;
        isDeath = true;
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
    }
    private void DestroyBird(){
        Destroy(gameObject);
    }
    IEnumerator UnlockAttack(){
        yield return new WaitForSeconds(0.2f);
        canAttack = true;
    }
}
