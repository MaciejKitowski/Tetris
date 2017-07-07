using UnityEngine;

public class TetrominoTile : MonoBehaviour {
    private GameObject collidedObject;

    void OnCollisionEnter2D(Collision2D collision) {
        collidedObject = collision.gameObject;
    }

    void OnCollisionStay2D(Collision2D collision) {
        collidedObject = collision.gameObject;
    }

    void OnCollisionExit2D(Collision2D collision) {
        collidedObject = null;    
    }

    public bool canRotate() {
        if (collidedObject == null) return false;
        else {
            if (!collidedObject.GetComponent<ArenaTile>().empty) return false;
            else return true;
        }
    }
}
