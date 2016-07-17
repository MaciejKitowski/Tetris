using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    private GameObject game;
    private BlocksArchitect blockCreator;

    void Awake() {
        game = GameObject.FindGameObjectWithTag("Game");
        blockCreator = FindObjectOfType<BlocksArchitect>();
    }

    public void buttonStartGame() {
        blockCreator.buttonBack();
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
