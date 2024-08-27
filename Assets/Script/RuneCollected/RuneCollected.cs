using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneCollected : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            GameObject.Find("RuneController").GetComponent<RuneController>().UpdateUI();
            gameObject.SetActive(false);
        }
    }
}
