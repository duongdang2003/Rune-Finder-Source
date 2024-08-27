using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private HingeJoint2D hingeJoint2D;
    private void Awake() {
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 7 && !other.gameObject.GetComponent<PlayerData>().havingKey){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerData>().havingKey = true;
            hingeJoint2D.connectedBody = player.GetComponent<Rigidbody2D>();
            hingeJoint2D.autoConfigureConnectedAnchor = false;
            GetComponent<Rigidbody2D>().mass = 0;
            if (player.transform.localScale.x > 0) hingeJoint2D.connectedAnchor = new Vector2(0.56f, 0);
            else hingeJoint2D.connectedAnchor = new Vector2(-0.56f, 0);
        }
    }
}
