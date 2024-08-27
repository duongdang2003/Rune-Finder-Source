using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    public string currentSkill;
    private PlayerMovement playerMovement;
    private float DEFAULT_JUMP_POWER, DEFAULT_GRAVITY;
    private Rigidbody2D rb;
    private TrailRenderer trailRenderer;
    public bool canSlash = false, canShoot = false, canLowGravity, isFalling = false, isSlashing = false;
    private GameObject player, bullet;
    private SoundController soundController;
    private void Awake() {
        trailRenderer = GetComponent<TrailRenderer>();
    }
    void Start()
    {
        soundController = GetComponent<SoundController>();
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        DEFAULT_JUMP_POWER = playerMovement.jumpPower;
        DEFAULT_GRAVITY = 4;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){

            //Slash
            if (canSlash)
            {
                // trailRenderer.emitting = true;
                playerMovement.lockMovement = true;
                rb.gravityScale = 0;
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(15 * player.transform.localScale.x*-1, 0), ForceMode2D.Impulse);
                canSlash = false;
                isSlashing = true;
                soundController.PlayDashSound();
                StartCoroutine(UnlockMovement());
                StartCoroutine(UnlockSlash());
            }

            //Bullet 
            else 
            if(canShoot)
            {
                Instantiate(bullet, player.transform.position, player.transform.rotation);
                canShoot = false;
                StartCoroutine(UnlockBullet());
            }
        }

        //low gravity
        if(canLowGravity){
            if(playerMovement.ground == null && rb.velocity.y < 0){
                rb.gravityScale = 0.5f;
            }
            else {
                rb.gravityScale = 4;
            }
        }

        // trail
        if(rb.velocity.x > 19 || rb.velocity.x < -19){
            trailRenderer.emitting = true;
        } else {
            trailRenderer.emitting = false;
        }
    }
    public void UpdateSkill(string skill){
        currentSkill = skill;
        ResetStat();
        if(skill == "Slash") canSlash = true;
        // Double Jump
        else if(skill == "DoubleJump") playerMovement.jumpPower = 23;
        else if(skill == "LowGravity") canLowGravity = true;
        else if(skill == "Bullet") canShoot = true;
    }
    private void ResetStat(){
        playerMovement.jumpPower = DEFAULT_JUMP_POWER;
        rb.gravityScale = DEFAULT_GRAVITY;
        canSlash = false;
        canShoot = false;
        canLowGravity = false;
    }
    IEnumerator UnlockMovement(){        
        yield return new WaitForSeconds(0.3f);
        playerMovement.lockMovement = false;
        rb.gravityScale = 4;
    }
    IEnumerator UnlockSlash(){
        yield return new WaitForSeconds(1f);
        if(currentSkill == "Slash")
        canSlash = true;
        // trailRenderer.emitting = false;
    }
    IEnumerator UnlockBullet(){
        yield return new WaitForSeconds(2f);
        if(currentSkill == "Bullet")
        canShoot = true;
    }
}
