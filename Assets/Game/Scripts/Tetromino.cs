using UnityEngine;

public class Tetromino : MonoBehaviour {
    [SerializeField]
    private bool rotation = true;

    //TODO Replace by Vector2i position
    public GameObject currentPosition;

    public void rotate() {
        if(rotation) {
            transform.Rotate(0, 0, 90f);
        }
    }

	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) rotate();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        currentPosition = collision.gameObject;    
    }
}
