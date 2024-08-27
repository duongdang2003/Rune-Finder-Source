using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneController : MonoBehaviour
{
    private PlayerRuneCollection playerRuneCollection;
    private Transform[] childrent;
    private int index = 3, currentRune = 1;
    public Sprite[] runeSprites;
    public PlayerSkillController playerSkillController;
    void Start()
    {
        playerRuneCollection = GameObject.Find("Player").GetComponent<PlayerRuneCollection>();
        childrent = GetComponentsInChildren<RectTransform>();
        playerSkillController = GameObject.Find("Player").GetComponent<PlayerSkillController>();

        UpdateUI();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentRune = 1;
            UpdateUI();
            playerSkillController.UpdateSkill("Slash");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentRune = 4;
            UpdateUI();
            playerSkillController.UpdateSkill("DoubleJump");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentRune = 7;
            UpdateUI();
            playerSkillController.UpdateSkill("Bullet");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentRune = 10;
            UpdateUI();
            playerSkillController.UpdateSkill("LowGravity");

        }

    }
    public void UpdateUI(){
        for (int i = 1; i < childrent.Length; i+=3){
            childrent[i].gameObject.SetActive(false);
        }
            foreach (string rune in playerRuneCollection.runeCollected)
            {
                childrent[index].GetComponent<Image>().sprite = checkRune(rune);
                childrent[index-2].gameObject.SetActive(true);
                if(index-2 == currentRune){
                    childrent[index - 2].gameObject.GetComponent<CanvasGroup>().alpha = 1;
                } else {
                    childrent[index - 2].gameObject.GetComponent<CanvasGroup>().alpha = 0.5f;
                }
                index += 3;
            }
        index = 3;
    }
    private Sprite checkRune(string runeName){
        if(runeName == "SlashRune") return runeSprites[0];
        if(runeName == "DoubleJumpRune") return runeSprites[1];
        if(runeName == "BulletRune") return runeSprites[2];
        if(runeName == "LowGravityRune") return runeSprites[3];
        return null;
    }
}
