using UnityEngine;

public class TetrominoSpawner : MonoBehaviour {
    [System.Serializable]
    private struct tetromino {
        public GameObject nextBlockUI;
        public GameObject prefab;
    }

    [SerializeField]
    private Transform startPosition;
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
        if (Input.GetKeyDown(KeyCode.Space)) spawn();
    }

    private void randNew() {
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

    public void spawn() {
        if(canSpawn()) {
            GameObject obj = Instantiate(tetrominoes[nextTetrominoID].prefab);

            var sprites = obj.GetComponentsInChildren<SpriteRenderer>();
            foreach (var spr in sprites) spr.color = nextTetrominoColor;
            obj.transform.position = startPosition.position;
            randNew();
        }
        else {
            Debug.Log("Cannot spawn");
        }
    }

    private bool canSpawn() {
        ArenaTile tl = startPosition.GetComponent<ArenaTile>();
        return tl.empty;
    }
}
