using UnityEngine;

public class Game : MonoBehaviour {
    public GameObject[] inputButtons = new GameObject[4];

    private pointsCounter points;
    private blocksManager managerBlocks;
    private nextBlockController nextBlock;
    private arenaManager managerArena;
    private GameObject controllerSettings;
    private EndGame endGame;

    void Awake() {
        points = FindObjectOfType<pointsCounter>();
        managerBlocks = FindObjectOfType<blocksManager>();
        nextBlock = FindObjectOfType<nextBlockController>();
        managerArena = FindObjectOfType<arenaManager>();
        controllerSettings = GameObject.FindGameObjectWithTag("Settings");
        endGame = FindObjectOfType<EndGame>();
        gameObject.SetActive(false);
    }

	public void newGame() {
        points.resetPoints();
        managerBlocks.removeAllBlocks();
        controllerSettings.SetActive(false);
        managerArena.resetArena();
        nextBlock.randNew();
        endGame.gameObject.SetActive(false);
    }

    public int getPoints() { return points.getPoints(); }
}
