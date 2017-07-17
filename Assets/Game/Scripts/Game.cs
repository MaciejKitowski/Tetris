using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [SerializeField]
    private Game_components.Tetromino _tetromino;
    //TODO Separate points to different class like Game_components.Tetromino class
    [SerializeField]
    private Text pointsField;
    [SerializeField]
    private int pointsPerRow = 15;
    private int points = 0;

    public Game_components.Tetromino tetromino { get { return _tetromino; } }

    void Start() {
        points = 0;
        pointsField.text = points.ToString();
    }

    public void addPoints() {
        points += pointsPerRow;
        pointsField.text = points.ToString();
    }
}