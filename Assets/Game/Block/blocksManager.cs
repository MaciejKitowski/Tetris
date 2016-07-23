using UnityEngine;
using System.Collections;

public class blocksManager : MonoBehaviour {
    public GameObject startTile;

    private nextBlockController nextBlock;
    private EndGame endGame;
    private float fallTimer = 0.6f;
    private const float moveDownMultiplier = 10f;

    void Awake() {
        nextBlock = GameObject.FindGameObjectWithTag("Game_nextBlocks").GetComponent<nextBlockController>();
        endGame = GameObject.FindGameObjectWithTag("Game_end").GetComponent<EndGame>();
    }

	void Update () { if (!GamePause.isPaused() && transform.childCount == 0) pushBlock(); }

    public void pushBlock() {
        if (!startTile.GetComponent<ArenaTile>().isEmpty) endGame.activate(Points.getPoints()); //Game lost condition
        else {
            GameObject buffer = Instantiate(nextBlock.getBlock()) as GameObject;
            buffer.transform.SetParent(transform);
            buffer.transform.SetAsLastSibling();
            buffer.transform.localScale = new Vector3(1, 1, 1);
            buffer.transform.localPosition = startTile.transform.localPosition;

            buffer.GetComponent<Block>().enabled = true;
            buffer.GetComponent<Block>().setSpeed(fallTimer - Level.getSpeedChange(), moveDownMultiplier);
            nextBlock.randNew();
        }
    }

    public void removeAllBlocks() { foreach(Transform obj in transform) Destroy(obj.gameObject); }
    public GameObject getBlock() { return transform.GetChild(transform.childCount - 1).gameObject; }
}
