using UnityEngine;

public class TetrominoTile : MonoBehaviour {
    private ArenaTile arenaTile;
    private Arena arena;

    void Start() {
        arena = GameObject.FindGameObjectWithTag("Arena").GetComponent<Arena>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        arenaTile = collision.gameObject.GetComponent<ArenaTile>();
    }

    void OnCollisionStay2D(Collision2D collision) {
        arenaTile = collision.gameObject.GetComponent<ArenaTile>();
    }

    void OnCollisionExit2D(Collision2D collision) {
        arenaTile = null;    
    }

    public bool canRotate() {
        if (arenaTile == null) return false;
        else return arenaTile.empty;
    }

    public bool canFallDown() {
        if (arenaTile.y + 2 > arena.maxTileY) return false;
        
        //TODO Check collision with locked arena tiles

        return true;
    }
}
