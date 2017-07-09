using UnityEngine;

public class TetrominoSpawner : MonoBehaviour {
    [System.Serializable]
    private struct tetromino {
        public GameObject nextBlockUI;
        public GameObject prefab;
    }

    [SerializeField]
    private tetromino[] tetrominoes;
}
