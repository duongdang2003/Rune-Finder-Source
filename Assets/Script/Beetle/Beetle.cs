using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : EnemyScript
{
    public float x, y, xSize, ySize, speed = 1;
    public Collider2D obstacle, ground, player;
    private Rigidbody2D rb;
    private float direct = -1;
    private bool isDeath = false;

    void Start()
    {
        speed = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        obstacle = Physics2D.OverlapBox(new Vector2(transform.position.x + 0.59f*direct, transform.position.y - 0.07f),
        new Vector2(0.04f, 1.18f), 0, LayerMask.GetMask("Ground"));

        ground = Physics2D.OverlapBox(new Vector2(transform.position.x + 0.72f*direct, transform.position.y - 0.6f),
        new Vector2(0.15f, 0.5f), 0, LayerMask.GetMask("Ground"));

        player = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y),
        new Vector2(0.95f, 1.35f), 0, LayerMask.GetMask("Player"));

        if(obstacle != null || ground == null && !isDeath) Flip();

        if(player != null && !isDeath){
            player.GetComponent<PlayerHealth>().TakeDamage(gameObject);
        }
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(speed * direct, rb.velocity.y);
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(new Vector2(transform.position.x - 0.59f*-direct, transform.position.y - 0.07f),
        new Vector2(0.04f, 1.18f));

        Gizmos.DrawWireCube(new Vector2(transform.position.x - 0.72f*-direct, transform.position.y - 0.6f),
        new Vector2(0.15f, 0.5f));

        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y),
        new Vector2(0.95f, 1.35f));

        Gizmos.DrawWireCube(new Vector2(transform.position.x + x*-direct, transform.position.y + y),
        new Vector2(xSize, ySize));
    }
    private void Flip(){
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        direct *= -1;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.gameObject.layer == 8){
            speed = 0;
            isDeath = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Animator>().SetTrigger("Death");
        }
    }
    private void DestroyBeetle(){
        Destroy(gameObject);
    }
    public override void Death(){
        speed = 0;
        isDeath = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Animator>().SetTrigger("Death");
        TurnOffHeadsLight();
    }
}
