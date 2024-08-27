using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public void Hide(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
