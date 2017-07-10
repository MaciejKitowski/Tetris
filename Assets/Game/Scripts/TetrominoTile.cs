using UnityEngine;

public class TetrominoTile : MonoBehaviour {
    static readonly string nullIngoreException = "Null reference to arena tile caused by collision detection speed, ignore that.";
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
        if (arenaTile == null) throw new System.NullReferenceException(nullIngoreException);

        if (arenaTile.y + 2 >= arena.maxTileY) return false;
        else if (!arena.tile[arenaTile.x, arenaTile.y + 1].empty) return false;

        return true;
    }

    public bool canTurn(Tetromino.TurnDirection dir) {
        if (arenaTile == null) throw new System.NullReferenceException(nullIngoreException);

        if(dir == Tetromino.TurnDirection.LEFT) {
            if (arenaTile.x <= 0) return false;
            if (!arena.tile[arenaTile.x - 1, arenaTile.y].empty) return false;
        }
        else {
            if (arenaTile.x + 1 >= arena.maxTileX) return false;
            if (!arena.tile[arenaTile.x + 1, arenaTile.y].empty) return false;
        }

        return true;
    }

    public void endFalling() {
        arenaTile.lockTile();
    }
}
