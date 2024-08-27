using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7){
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if(playerHealth.health < 3){
                playerHealth.health += 1;
                playerHealth.UpdateHealth(playerHealth.health);
                Destroy(gameObject);
            }
        }
    }
}
