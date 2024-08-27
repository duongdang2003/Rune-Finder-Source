using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float horizontal;
    public float speed = 2, jumpPower = 6;
    public float x,y,xSize,ySize;
    public Collider2D ground;
    public bool lockMovement = false;
    public Sprite IDLE, JUMP;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        ground = Physics2D.OverlapBox(new Vector2(transform.position.x + 0.005f, transform.position.y - 0.51f),
        new Vector2(0.8f, 0.13f), 0, LayerMask.GetMask("Ground"));

        if(Input.GetKeyDown(KeyCode.Space) && ground != null){
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        if(ground == null){
            animator.SetTrigger("Jump");
        } if(horizontal != 0 && ground != null){
            animator.SetTrigger("Walk");
        }
        else if(horizontal == 0 && ground != null){
            animator.SetTrigger("Idle");
        }
    }
    private void FixedUpdate() {
        if(!lockMovement)
        rb.velocity = new Vector2(speed*horizontal, rb.velocity.y);
    }
    private void Flip(){
        if(horizontal == 1 && transform.localScale.x > 0 || horizontal == -1 && transform.localScale.x < 0)
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(new Vector2(transform.position.x + x, transform.position.y + y),
        new Vector2(xSize, ySize));
    }
}
