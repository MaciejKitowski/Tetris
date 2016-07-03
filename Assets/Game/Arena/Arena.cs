using UnityEngine;
using System.Collections;

public class Arena : MonoBehaviour {
    public ArenaTile[,] tile = new ArenaTile[10,20];

    void Awake() {
        for(int y = 0; y < 20; ++y) {
            for(int x = 0; x < 10; ++x) {
                tile[x, y] = transform.GetChild(y).GetChild(x).GetComponent<ArenaTile>();
                tile[x, y].setPosition(x, y);
            }
        }
    }

    void Update() {
        for(int y = 0; y < 20; ++y) if (lineFilled(y) && lineFilledInOneColor(y)) addPoints(y);
    }

    public bool lineFilled(int y) {
        for(int x = 0; x < 10; ++x) if (tile[x, y].isEmpty) return false;
        return true;
    }

    public bool lineFilledInOneColor(int y) {
        BlockTile.blockColor col = tile[0, y].blockTile.GetComponent<BlockTile>().color;
        for (int x = 1; x < 10; ++x) if (tile[x, y].blockTile.GetComponent<BlockTile>().color != col) return false;
        return true;
    }

    public void addPoints(int y) {
        for (int x = 9; x >= 0; --x) {
            Destroy(tile[x, y].blockTile);
            tile[x, y].isEmpty = true;
        }
        Points.addPoints(50);
    }

    public void resetArena() { foreach(ArenaTile obj in tile) obj.isEmpty = true; }
}
