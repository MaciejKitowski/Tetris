using UnityEngine;

public class ArenaTile : MonoBehaviour {
    [SerializeField]
    private bool _empty = true;
    private int _x, _y;
    private TetrominoTile tile;

    public bool empty { get { return _empty; } private set { _empty = value; } }
    public int x { get { return _x; } private set { _x = value; } }
    public int y { get { return _y; } private set { _y = value; } }

    void Awake() {
        if(!int.TryParse(transform.name, out _x) || !int.TryParse(transform.parent.name, out _y)) {
            Debug.LogError(string.Format("Cannot parse arena position: x = {0}  y = {1}", transform.name, transform.parent.name), gameObject);
        }
        else {
            x -= 1;
            y -= 1;
        }
    }

    public void lockTile(TetrominoTile tile) {
        empty = false;
        this.tile = tile;
    }

    public void unlockTile() {
        empty = true;
        tile = null;
    }

    public void removeTetrominoTile() {
        Destroy(tile.gameObject);
        unlockTile();
    }
}
