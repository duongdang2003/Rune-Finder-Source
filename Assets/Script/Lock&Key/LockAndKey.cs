using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAndKey : MonoBehaviour
{
    public GameObject key;
    public void Finish(){
        Destroy(gameObject);
    }
}
