using UnityEngine;

public class Tetromino : MonoBehaviour {
    [SerializeField]
    private bool rotation = true;

    public void rotate() {
        if(rotation) {
            transform.Rotate(0, 0, 90f);
        }
    }

	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) rotate();
    }
}
