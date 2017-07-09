using System.Collections;
using UnityEngine;

public class Tetromino : MonoBehaviour {
    [SerializeField]
    private bool rotation = true;
    private TetrominoTile[] rotationColliders = new TetrominoTile[4];
    private TetrominoTile[] tetrominoTiles = new TetrominoTile[4];
    private Game game;

    void Start() {
        rotationColliders = transform.GetChild(0).GetComponentsInChildren<TetrominoTile>();
        for (int i = 1; i < transform.childCount; ++i) tetrominoTiles[i - 1] = transform.GetChild(i).GetComponent<TetrominoTile>();
        game = Camera.main.GetComponent<Game>();
        StartCoroutine(fallingCoroutine());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) rotate();
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
            yield return new WaitForSeconds(game.tetrominoFallTime);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4096f, transform.position.z);

            foreach(var tile in tetrominoTiles) {
                if(!tile.canFallDown()) {
                    falling = false;
                    break;
                }
            }
        }
    }
}
