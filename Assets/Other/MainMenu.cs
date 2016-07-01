using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    private GameObject game;

    void Awake() { game = GameObject.FindGameObjectWithTag("Game"); }

    public void buttonStartGame() {
        game.SetActive(true);
        game.GetComponent<Game>().activatePause();
        game.GetComponent<Game>().newGame();
        gameObject.SetActive(false);
    }

    public void buttonExitGame() { Application.Quit(); }
}
