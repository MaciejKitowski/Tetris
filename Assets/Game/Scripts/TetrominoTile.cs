using UnityEngine;

public class TetrominoTile : MonoBehaviour {
    public GameObject collidedObject;

    void OnCollisionEnter2D(Collision2D collision) {
        collidedObject = collision.gameObject;
    }
}
