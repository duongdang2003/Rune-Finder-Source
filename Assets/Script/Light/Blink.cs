using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Blink : MonoBehaviour
{
    public Light2D light2D;
    public float limit, step;
    private float direct;
    private bool turnOff = false;
    void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.intensity = 0;
        direct = 1;
    }

    void Update()
    {
        if(!turnOff){
            light2D.intensity += step*direct;
            if(light2D.intensity > limit || light2D.intensity < 0) direct *= -1;
        } else {
            light2D.intensity = 0;
        }
        
    }

    public void TurnOffLight(){
        turnOff = true;
    }
}
