using UnityEngine;
using System.Collections;

public class arenaTileController : MonoBehaviour {
    public int posX, posY;
    public bool isEmpty = true;
    public GameObject blockTile;

    void Awake() {
        char[] splitChars = { '(', ',', ')' };
        string[] buffer = transform.name.Split(splitChars);
        posX = int.Parse(buffer[1]);
        posY = int.Parse(buffer[2]);
    }

    void OnCollisionEnter2D(Collision2D obj) {
        if(obj.transform.tag == "Game_blockTile") {
            blockTile = obj.gameObject;
            isEmpty = false;
        }
    }

    void OnCollisionStay2D(Collision2D obj) {
        if (obj.transform.tag == "Game_blockTile") {
            blockTile = obj.gameObject;
            isEmpty = false;
        }
    }

    void OnCollisionExit2D(Collision2D obj) {
        if (obj.transform.tag == "Game_blockTile") {
            blockTile = null;
            isEmpty = true;
        }
    }
}
