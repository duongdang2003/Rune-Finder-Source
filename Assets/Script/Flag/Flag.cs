using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Flag : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 7) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
