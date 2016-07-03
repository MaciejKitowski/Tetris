using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {
    public Text pointsValue;

    private Game game;
    private MainMenu menu;

    void Awake() {
        game = FindObjectOfType<Game>();
        menu = FindObjectOfType<MainMenu>();
    }

    public void activate(int points) {
        gameObject.SetActive(true);
        GamePause.activate();
        pointsValue.text = points.ToString();
    }

	public void buttonAgain() { game.newGame(); }
    public bool isActive() { return gameObject.activeInHierarchy; }

    public void buttonBack() {
        gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
}
