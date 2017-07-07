using UnityEngine;

public class Game : MonoBehaviour {
    //[SerializeField]
    private float _tetrominoFallTime = 1.0f;

    public float tetrominoFallTime { get { return _tetrominoFallTime; } private set { _tetrominoFallTime = value; } }
}
