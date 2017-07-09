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
        if (!arena.tile[arenaTile.x - 1, arenaTile.y + 1].empty) return false;

        return true;
    }

    public bool canMoveLeft() {
        if (arenaTile.x - 1 < 1) return false;
        if (!arena.tile[arenaTile.x - 2, arenaTile.y - 1].empty) return false;

        return true;
    }

    public bool canMoveRight() {
        if (arenaTile.x + 1 > arena.maxTileX) return false;
        if (!arena.tile[arenaTile.x, arenaTile.y - 1].empty) return false;

        return true;
    }
}
