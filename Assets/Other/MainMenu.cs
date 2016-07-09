using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    private GameObject game;
    private BlockCreator blockCreator;

    void Awake() {
        game = GameObject.FindGameObjectWithTag("Game");
        blockCreator = FindObjectOfType<BlockCreator>();
    }

    public void buttonStartGame() {
        blockCreator.gameObject.SetActive(false);
        game.SetActive(true);
        GamePause.activate();
        game.GetComponent<Game>().newGame();
        gameObject.SetActive(false);
    }

    public void buttonBlocksCreator() {
        game.GetComponent<Game>().newGame();
        gameObject.SetActive(false);
        blockCreator.activate();
    }

    public void buttonExitGame() { Application.Quit(); }
}
