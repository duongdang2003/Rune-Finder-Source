using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        transform.localScale = new Vector3(Screen.width, Screen.height, 0);
    }
    public void loadNewLevel(){
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator Transition(int levelIndex){
        animator.SetTrigger("Switch");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelIndex + 1);
    }
}
