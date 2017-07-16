using System.Collections;
using UnityEngine;

public class Tetromino : MonoBehaviour {
    public enum TurnDirection { LEFT = -1, RIGHT = 1 }

    [SerializeField]
    private bool rotation = true;
    private readonly float tileSize = 0.4096f;
    private TetrominoTile[] tetrominoTiles = new TetrominoTile[4];
    private TetrominoRotationTile[] rotationTiles;
    private Game game;
    private float fallingTime;
    private TetrominoSpawner spawner;

    void Start() {
        rotationTiles = GetComponentsInChildren<TetrominoRotationTile>();

        for (int i = 1; i < transform.childCount; ++i) tetrominoTiles[i - 1] = transform.GetChild(i).GetComponent<TetrominoTile>();
        game = Camera.main.GetComponent<Game>();
        spawner = GameObject.FindGameObjectWithTag("TetrominoSpawner").GetComponent<TetrominoSpawner>();
        fallingTime = game.tetrominoFallTime;
        StartCoroutine(fallingCoroutine());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) rotate();
        if (Input.GetKeyDown(KeyCode.S)) speedUpFalling();
        if (Input.GetKeyDown(KeyCode.A)) turn(TurnDirection.LEFT);
        if (Input.GetKeyDown(KeyCode.D)) turn(TurnDirection.RIGHT);
    }

    private void rotate() {
        if(rotation && canRotate()) {
            for (int i = 0; i < rotationTiles.Length; ++i) tetrominoTiles[i].rotate(rotationTiles[i]);
            transform.Rotate(0, 0, 90f);
        }
    }

	private bool canRotate() {
        foreach(var obj in rotationTiles) {
            if (!obj.canRotate) return false;
            else continue;
        }
        return true;
    }

    private IEnumerator fallingCoroutine() {
        bool falling = true;

        while(falling) {
            yield return new WaitForSeconds(fallingTime);

            foreach(var tile in tetrominoTiles) {
                falling = tile.canFallDown();
                if (!falling) break;
            }

            if (falling) {
                foreach (var tile in tetrominoTiles) tile.fallDownOnce();

                transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, transform.position.z);
            }
        }

        if(!falling) endFalling();
    }

    private void turn(TurnDirection dir) {
        bool canTurn = true;

        foreach(var tile in tetrominoTiles) {
            canTurn = tile.canTurn(dir);
            if (!canTurn) break;
        }

        if (canTurn) {
            foreach (var tile in tetrominoTiles) tile.turn(dir);

            if (dir == TurnDirection.LEFT) transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, transform.position.z);
            else transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, transform.position.z);
        }
    }

    private void speedUpFalling() {
        fallingTime *= game.speedUpMultiplier;
    }

    private void endFalling() {
        foreach (var tile in tetrominoTiles) tile.endFalling();

        spawner.spawn();
        Destroy(transform.GetChild(0).gameObject); //Rotation colliders
        Destroy(this);
    }
}
