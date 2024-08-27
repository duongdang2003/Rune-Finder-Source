using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public virtual void Death(){

    }
    public void TurnOffHeadsLight(){
        Blink blink = GetComponentInChildren<Blink>();

        if(blink != null) blink.TurnOffLight();
    }
}
