using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7){
            other.gameObject.GetComponent<PlayerHealth>().Death();
        }
   }
}
