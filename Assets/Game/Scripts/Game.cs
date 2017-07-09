using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField]
    private float _tetrominoFallTime = 1.0f;
    [SerializeField]
    private float _speedUpMultiplier = 0.1f;

    public float tetrominoFallTime { get { return _tetrominoFallTime; } private set { _tetrominoFallTime = value; } }
    public float speedUpMultiplier { get { return _speedUpMultiplier; } private set { _speedUpMultiplier = value; } }
}
