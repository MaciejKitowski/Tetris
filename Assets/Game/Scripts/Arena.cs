using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {
    private ArenaTile[,] _tile;
    private int _maxTileX;
    private int _maxTileY;
    private Game game;
    private Queue<int> rowsToCheck;

    public ArenaTile[,] tile { get { return _tile; } private set { _tile = value; } }
    public int maxTileX { get { return _maxTileX; } private set { _maxTileX = value; } }
    public int maxTileY { get { return _maxTileY; } private set { _maxTileY = value; } }

    void Awake() {
        maxTileX = transform.GetChild(0).childCount;
        maxTileY = transform.childCount;
        tile = new ArenaTile[maxTileX, maxTileY];
        game = Camera.main.GetComponent<Game>();
        rowsToCheck = new Queue<int>();

        for(int y = 0; y < maxTileY; ++y) {
            for(int x = 0; x < maxTileX; ++x) {
                tile[x, y] = transform.GetChild(y).GetChild(x).GetComponent<ArenaTile>();
            }
        }

        StartCoroutine(checkRowCoroutine());
    }

    public void addRowToCheck(int row) {
        if(!rowsToCheck.Contains(row)) rowsToCheck.Enqueue(row);
    }

    private IEnumerator checkRowCoroutine() {
        while(true) {
            if (rowsToCheck.Count == 0) yield return null;
            else {
                yield return new WaitForEndOfFrame();
                checkRow(rowsToCheck.Dequeue());
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void checkRow(int row) {
        int counter = 0;

        for (int x = 0; x < maxTileX; ++x) {
            if (tile[x, row].empty) break;
            else ++counter;
        }

        if (counter == maxTileX) {
            game.addPoints();

            for (int x = 0; x < maxTileX; ++x) tile[x, row].removeTetrominoTile();

            for (int y = row - 1; y >= 0; --y) {
                for (int x = 0; x < maxTileX; ++x) tile[x, y].tetrominoFalldown();
            }
        }
    }
}
