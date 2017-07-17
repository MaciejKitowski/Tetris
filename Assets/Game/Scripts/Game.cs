using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [SerializeField]
    private float _tetrominoFallTime = 1.0f;
    [SerializeField]
    private float _speedUpMultiplier = 0.1f;
    [SerializeField]
    private Text pointsField;
    [SerializeField]
    private int pointsPerRow = 15;

    private int points = 0;

    public float tetrominoFallTime { get { return _tetrominoFallTime; } private set { _tetrominoFallTime = value; } }
    public float speedUpMultiplier { get { return _speedUpMultiplier; } private set { _speedUpMultiplier = value; } }

    void Start() {
        points = 0;
        pointsField.text = points.ToString();
    }

    public void addPoints() {
        points += pointsPerRow;
        pointsField.text = points.ToString();
    }
}
