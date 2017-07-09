using System.Collections;
using UnityEngine;

public class Tetromino : MonoBehaviour {
    [SerializeField]
    private bool rotation = true;
    private const float tileSize = 0.4096f;
    private TetrominoTile[] rotationColliders = new TetrominoTile[4];
    private TetrominoTile[] tetrominoTiles = new TetrominoTile[4];
    private Game game;
    private float fallingTime;

    void Start() {
        rotationColliders = transform.GetChild(0).GetComponentsInChildren<TetrominoTile>();
        for (int i = 1; i < transform.childCount; ++i) tetrominoTiles[i - 1] = transform.GetChild(i).GetComponent<TetrominoTile>();
        game = Camera.main.GetComponent<Game>();
        fallingTime = game.tetrominoFallTime;
        StartCoroutine(fallingCoroutine());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) rotate();
        if (Input.GetKeyDown(KeyCode.S)) speedUpFalling();
        if (Input.GetKeyDown(KeyCode.A)) moveLeft();
        if (Input.GetKeyDown(KeyCode.D)) moveRight();
    }

    private void rotate() {
        if(rotation && canRotate()) transform.Rotate(0, 0, 90f);
    }

	private bool canRotate() {
        foreach(var obj in rotationColliders) {
            if (!obj.canRotate()) return false;
        }
        return true;
    }

    private IEnumerator fallingCoroutine() {
        bool falling = true;

        while(falling) {
            yield return new WaitForSeconds(fallingTime);
            transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, transform.position.z);

            foreach(var tile in tetrominoTiles) {
                if(!tile.canFallDown()) {
                    falling = false;
                    break;
                }
            }
        }

        if(!falling) {
            //TODO delete Tetromino script, spawn next block, lock arena tile etc.
        }
    }

    private void moveLeft() {
        //TODO check if can move left
        transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, transform.position.z);
    }

    private void moveRight() {
        //TODO check if can move right
        transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, transform.position.z);
    }

    private void speedUpFalling() {
        fallingTime *= game.speedUpMultiplier;
    }
}
