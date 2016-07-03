using UnityEngine;
using System.Collections;

public class ArenaTile : MonoBehaviour {
    public int posX, posY;
    public bool isEmpty = true;
    public GameObject blockTile;

    public void setPosition(int x, int y) {
        posX = x;
        posY = y;
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
