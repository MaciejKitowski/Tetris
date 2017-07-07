using UnityEngine;

public class Tetromino : MonoBehaviour {
    [SerializeField]
    private bool rotation = true;
    private TetrominoTile[] rotationColliders;

    void Start() {
        rotationColliders = transform.GetChild(0).GetComponentsInChildren<TetrominoTile>();
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
}
