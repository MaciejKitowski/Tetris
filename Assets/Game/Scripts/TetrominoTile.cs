using UnityEngine;

public class TetrominoTile : MonoBehaviour {
    private ArenaTile collidedObject;

    void OnCollisionEnter2D(Collision2D collision) {
        collidedObject = collision.gameObject.GetComponent<ArenaTile>();
    }

    void OnCollisionStay2D(Collision2D collision) {
        collidedObject = collision.gameObject.GetComponent<ArenaTile>();
    }

    void OnCollisionExit2D(Collision2D collision) {
        collidedObject = null;    
    }

    public bool canRotate() {
        if (collidedObject == null) return false;
        else return collidedObject.empty;
    }

    public bool canFallDown() {
        //TODO Check collision with arena border
        //TODO Check collision with locked arena tiles

        return true;
    }
}
