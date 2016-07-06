using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {
    public Text pointsValue;

    private Game game;
    private MainMenu menu;
    private Animation anim;

    void Awake() {
        game = FindObjectOfType<Game>();
        menu = FindObjectOfType<MainMenu>();
        anim = GetComponent<Animation>();
    }

    public void activate(int points) {
        gameObject.SetActive(true);
        GamePause.activate();
        pointsValue.text = points.ToString();
        anim.Play("EndGameDisplay");
    }

	public void buttonAgain() { game.newGame(); }
    public bool isActive() { return gameObject.activeInHierarchy; }

    public void buttonBack() {
        gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
}
