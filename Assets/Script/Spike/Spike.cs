using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private bool isWaiting = false;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 7 && !isWaiting) 
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage(gameObject);
        isWaiting = true;
        StartCoroutine(HitCd());
    }
    IEnumerator HitCd(){
        yield return new WaitForSeconds(0.1f);
        isWaiting = false;
    }
}
