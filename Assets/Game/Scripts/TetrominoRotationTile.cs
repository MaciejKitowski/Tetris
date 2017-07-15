using UnityEngine;

public class TetrominoRotationTile : MonoBehaviour {
    private bool _canRotate = false;

    public bool canRotate { get { return _canRotate; } private set { _canRotate = value; } }

    void OnCollisionEnter2D(Collision2D collision) { checkRotation(collision); }
    void OnCollisionStay2D(Collision2D collision) { checkRotation(collision); }
    void OnCollisionExit2D(Collision2D collision) { canRotate = false; }

    private void checkRotation(Collision2D collision) {
        ArenaTile tile = collision.gameObject.GetComponent<ArenaTile>();
        if (tile.empty) canRotate = true;
        else canRotate = false;
    }
}
