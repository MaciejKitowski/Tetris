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
    private SwipeInput input;

    void Start() {
        rotationTiles = GetComponentsInChildren<TetrominoRotationTile>();

        for (int i = 1; i < transform.childCount; ++i) tetrominoTiles[i - 1] = transform.GetChild(i).GetComponent<TetrominoTile>();
        game = Camera.main.GetComponent<Game>();
        input = Camera.main.GetComponent<SwipeInput>();
        spawner = GameObject.FindGameObjectWithTag("TetrominoSpawner").GetComponent<TetrominoSpawner>();
        fallingTime = game.tetromino.fallTime;

        assignToInputEvents();
        StartCoroutine(fallingCoroutine());
    }

    private void assignToInputEvents() {
        input.SwipedUp += rotate;
        input.SwipedDown += boostFalling;
        input.SwipedLeft += turnLeft;
        input.SwipedRight += turnRight;
    }

    private void removeFromInputEvents() {
        input.SwipedUp -= rotate;
        input.SwipedDown -= boostFalling;
        input.SwipedLeft -= turnLeft;
        input.SwipedRight -= turnRight;
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

            if(!game.pause.paused) {
                foreach (var tile in tetrominoTiles) {
                    falling = tile.canFallDown();
                    if (!falling) break;
                }

                if (falling) {
                    foreach (var tile in tetrominoTiles) tile.fallDownOnce();

                    transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, transform.position.z);
                }
            }
        }

        if(!falling) endFalling();
    }

    private void turnLeft() { turn(TurnDirection.LEFT); }
    private void turnRight() { turn(TurnDirection.RIGHT); }

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

    private void boostFalling() {
        fallingTime = game.tetromino.fallTimeBoosted;
    }

    private void endFalling() {
        removeFromInputEvents();
        foreach (var tile in tetrominoTiles) tile.endFalling();

        spawner.spawn();
        Destroy(transform.GetChild(0).gameObject); //Rotation colliders
        Destroy(GetComponent<Rigidbody>());
        Destroy(this);
    }
}
