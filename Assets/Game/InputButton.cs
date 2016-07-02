using UnityEngine;
using System.Collections;

public class InputButton : MonoBehaviour {
    public GameObject[] button = new GameObject[4];

    private EndGame endgame;
    private blocksManager blocks;

    void Awake() {
        endgame = FindObjectOfType<EndGame>();
        blocks = FindObjectOfType<blocksManager>();
    }

    public void actvate() { foreach (GameObject obj in button) obj.SetActive(true); }
    public void deactivate() { foreach (GameObject obj in button) obj.SetActive(false); }

    public void moveLeft() {
        if (!GamePause.isPaused() && !endgame.isActive()) blocks.getBlock().GetComponent<Block>().turnLeft();
        else if(GamePause.isPaused() && !endgame.isActive()) GamePause.deactivate();
    }

    public void moveRight() {
        if (!GamePause.isPaused() && !endgame.isActive()) blocks.getBlock().GetComponent<Block>().turnRight();
        else if (GamePause.isPaused() && !endgame.isActive()) GamePause.deactivate();
    }

    public void moveDown() {
        if (!GamePause.isPaused() && !endgame.isActive()) blocks.getBlock().GetComponent<Block>().speedUp = true;
        else if (GamePause.isPaused() && !endgame.isActive()) GamePause.deactivate();
    }

    public void rotate() {
        if (!GamePause.isPaused() && !endgame.isActive()) blocks.getBlock().GetComponent<Block>().rotate();
        else if (GamePause.isPaused() && !endgame.isActive()) GamePause.deactivate();
    }
}
