using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    private GameObject game;

    void Awake() { game = GameObject.FindGameObjectWithTag("Game"); }

    public void buttonStartGame() {
        game.SetActive(true);
        GamePause.activate();
        game.GetComponent<Game>().newGame();
        gameObject.SetActive(false);
    }

    public void buttonBlocksCreator() { }

    public void buttonExitGame() { Application.Quit(); }
}
