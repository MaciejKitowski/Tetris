using UnityEngine;

public class Game : MonoBehaviour {
    public GameObject[] inputButtons = new GameObject[4];

    private blocksManager managerBlocks;
    private nextBlockController nextBlock;
    private Arena managerArena;
    private GameObject controllerSettings;
    private EndGame endGame;

    void Awake() {
        managerBlocks = GameObject.FindGameObjectWithTag("Game_blocks").GetComponent<blocksManager>();
        nextBlock = GameObject.FindGameObjectWithTag("Game_nextBlocks").GetComponent<nextBlockController>();
        managerArena = GameObject.FindGameObjectWithTag("Game_arena").GetComponent<Arena>();
        endGame = GameObject.FindGameObjectWithTag("Game_end").GetComponent<EndGame>();
        controllerSettings = GameObject.FindGameObjectWithTag("Settings");
        GetComponent<InputButton>().initiate(endGame, managerBlocks);
        GetComponent<InputSwipe>().initiate(endGame, managerBlocks, controllerSettings.GetComponent<Settings>());
        GetComponent<InputTap>().initiate(endGame, managerBlocks, controllerSettings.GetComponent<Settings>());
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
