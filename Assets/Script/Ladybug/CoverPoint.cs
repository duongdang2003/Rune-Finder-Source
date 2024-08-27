using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.gameObject.layer == 7){
            // other.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(gameObject);
            Debug.Log("Jump");
        }
    }
}
