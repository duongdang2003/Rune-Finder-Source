using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Pathfinding;

public class AngryBox : EnemyScript
{
    public Sprite calm, angry;
    // private AIPath aIPath;
    private Collider2D player, detect;
    public float x, y, xSize, ySize;
    void Start()
    {
        // aIPath = GetComponent<AIPath>();
    }

    void Update()
    {
        player = Physics2D.OverlapBox(transform.position, new Vector2(0.8f, 0.8f), 0, LayerMask.GetMask("Player"));
        detect = Physics2D.OverlapBox(transform.position, new Vector2(14, 14), 0, LayerMask.GetMask("Player"));

        if (detect != null)
        {
            // aIPath.canMove = true;
            GetComponent<SpriteRenderer>().sprite = angry;
            GetComponent<Animator>().SetTrigger("Angry");

        }
        else
        {
            // aIPath.canMove = false;
            GetComponent<SpriteRenderer>().sprite = calm;
            GetComponent<Animator>().SetTrigger("Calm");
        }
        if(player != null){
            player.gameObject.GetComponent<PlayerHealth>().TakeDamage(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            Death();
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(new Vector2(transform.position.x + x, transform.position.y + y),
        new Vector2(xSize, ySize));
    }
    public override void Death(){
        // aIPath.canMove = false;
        GetComponent<Animator>().SetTrigger("Death");
    }
    private void DestroyAngryBox(){
        Destroy(gameObject);
    }
    
}
