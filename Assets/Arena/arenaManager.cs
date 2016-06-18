using UnityEngine;
using System.Collections;

public class arenaManager : MonoBehaviour {
    public arenaTileController[,] tile = new arenaTileController[10,20];

    private pointsCounter points;

    void Awake() {
        char[] splitChars = { '(', ',', ')' };

        for (int y = 0; y < 20; ++y) {
            foreach (Transform obj in transform.GetChild(y).gameObject.transform) {
                string[] buffer = obj.name.Split(splitChars);
                tile[int.Parse(buffer[1]), y] = obj.gameObject.GetComponent<arenaTileController>();
            }
        }
        points = FindObjectOfType<pointsCounter>();
    }

    void Update() {
        for(int y = 0; y < 20; ++y) if (lineFilled(y) && lineFilledInOneColor(y)) addPoints(y);
    }

    public bool lineFilled(int y) {
        for(int x = 0; x < 10; ++x) if (tile[x, y].isEmpty) return false;
        return true;
    }

    public bool lineFilledInOneColor(int y) {
        blockTileController.blockColor col = tile[0, y].blockTile.GetComponent<blockTileController>().color;
        for (int x = 1; x < 10; ++x) if (tile[x, y].blockTile.GetComponent<blockTileController>().color != col) return false;
        return true;
    }

    public void addPoints(int y) {
        for (int x = 9; x >= 0; --x) {
            Destroy(tile[x, y].blockTile);
            tile[x, y].isEmpty = true;
        }
        points.addPoints(50);
    }

    public void resetArena() {
        foreach(arenaTileController obj in tile) obj.isEmpty = true;
    }
}
