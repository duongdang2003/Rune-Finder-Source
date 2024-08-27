using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float direct, speed;
    void Start()
    {
        direct = GameObject.Find("Player").transform.localScale.x < 0 ? 1 : -1;
        speed = 0.1f;

        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed*direct, transform.position.y);
    }
    IEnumerator DestroyBullet(){
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.layer == 6)
        {
            other.gameObject.GetComponent<EnemyScript>().Death();
            Destroy(gameObject);
        }
        if(other.collider.gameObject.layer == 3) Destroy(gameObject);

    }

}
