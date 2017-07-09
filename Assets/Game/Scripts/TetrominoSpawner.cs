using UnityEngine;

public class TetrominoSpawner : MonoBehaviour {
    [System.Serializable]
    private struct tetromino {
        public GameObject nextBlockUI;
        public GameObject prefab;
    }

    [SerializeField]
    private tetromino[] tetrominoes;
    [SerializeField]
    private Color[] possibleColors;
    private int nextTetrominoID;
    private Color nextTetrominoColor;

    void Start() {
        randNew();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) randNew();   
    }

    public void randNew() {
        foreach(var tt in tetrominoes) {
            tt.nextBlockUI.SetActive(false);
        }

        nextTetrominoID = Random.Range(0, tetrominoes.Length);
        nextTetrominoColor = possibleColors[Random.Range(0, possibleColors.Length)];
        tetrominoes[nextTetrominoID].nextBlockUI.SetActive(true);

        foreach(Transform tt in tetrominoes[nextTetrominoID].nextBlockUI.transform) {
            tt.GetComponent<SpriteRenderer>().color = nextTetrominoColor;
        }
    }
}
