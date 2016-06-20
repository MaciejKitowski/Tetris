using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class endGameController : MonoBehaviour {
    public Text pointsValue;

    private gameController game;
    private menuController menu;

    void Awake() {
        game = FindObjectOfType<gameController>();
        menu = FindObjectOfType<menuController>();
    }

    public void activate(int points) {
        gameObject.SetActive(true);
        game.activatePause();
        pointsValue.text = points.ToString();
    }

	public void buttonAgain() { game.newGame(); }

    public void buttonBack() {
        gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
}
