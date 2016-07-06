using UnityEngine;

public class Game : MonoBehaviour {
    public GameObject[] inputButtons = new GameObject[4];

    private blocksManager managerBlocks;
    private nextBlockController nextBlock;
    private Arena managerArena;
    private GameObject controllerSettings;
    private EndGame endGame;

    void Awake() {
        managerBlocks = FindObjectOfType<blocksManager>();
        nextBlock = FindObjectOfType<nextBlockController>();
        managerArena = FindObjectOfType<Arena>();
        controllerSettings = GameObject.FindGameObjectWithTag("Settings");
        endGame = FindObjectOfType<EndGame>();
        gameObject.SetActive(false);
    }

	public void newGame() {
        Points.resetPoints();
        managerBlocks.removeAllBlocks();
        controllerSettings.SetActive(false);
        managerArena.resetArena();
        nextBlock.randNew();
        Level.reset();
        endGame.gameObject.SetActive(false);
    }
}
