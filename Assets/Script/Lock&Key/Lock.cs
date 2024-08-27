using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public LockAndKey controller;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetInstanceID() == controller.key.GetInstanceID()){
            Destroy(controller.gameObject);
        }
    }
}
