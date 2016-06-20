using UnityEngine;
using System.Collections;

public class blocksManager : MonoBehaviour {
    public GameObject startTile;

    private nextBlockController nextBlock;
    private gameController game;
    private endGameController endGame;

	void Awake() {
        nextBlock = FindObjectOfType<nextBlockController>();
        game = FindObjectOfType<gameController>();
        endGame = FindObjectOfType<endGameController>();
    }

	void Update () { if (!game.paused && transform.childCount == 0) pushBlock(); }

    public void pushBlock() {
        if (!startTile.GetComponent<arenaTileController>().isEmpty) endGame.activate(game.getPoints()); //Game lost condition
        else {
            GameObject buffer = Instantiate(nextBlock.getBlock()) as GameObject;
            buffer.transform.SetParent(transform);
            buffer.transform.SetAsLastSibling();
            buffer.transform.localPosition = startTile.transform.localPosition;

            buffer.GetComponent<blockController>().enabled = true;
            nextBlock.randNew();
        }
    }

    public void removeAllBlocks() { foreach(Transform obj in transform) Destroy(obj.gameObject); }
    public GameObject getBlock() { return transform.GetChild(transform.childCount - 1).gameObject; }
}
