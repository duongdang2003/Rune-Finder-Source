using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    public float maxHeight, minHeigh;
    public float step;

    void Start()
    {
        minHeigh = transform.position.y;
        maxHeight = transform.position.y + maxHeight;
    }

    private void FixedUpdate() {
        transform.position = new Vector2(transform.position.x, transform.position.y + step);
        if(transform.position.y > maxHeight || transform.position.y < minHeigh) step *= -1;
    }
}
