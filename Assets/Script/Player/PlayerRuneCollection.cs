using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRuneCollection : MonoBehaviour
{
    public Sprite[] runeSprite;
    public List<string> runeCollected = new List<string>();
    private void Start() {
        // runeCollected.Add("Slash");
        // runeCollected.Add("DoubleJump");
        // runeCollected.Add("Bullet");
        // runeCollected.Add("LowGravity");

    }
    public void AddRune(string runeName){
        runeCollected.Add(runeName);
    }
}
