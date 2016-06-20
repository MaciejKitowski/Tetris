using UnityEngine;
using System.Collections;

public class exitButtonController : MonoBehaviour {
    private GameObject game;
    private GameObject menu;
    private GameObject settings;
    private GameObject endGame;

    void Awake() {
        game = GameObject.FindGameObjectWithTag("Game");
        menu = GameObject.FindGameObjectWithTag("MainMenu");
        settings = GameObject.FindGameObjectWithTag("Settings");
        endGame = GameObject.FindGameObjectWithTag("Game_end");
    }

	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape)) {

            if(settings.activeInHierarchy) {
                settings.GetComponent<settingsController>().saveSettings();
                game.GetComponent<gameController>().deactivatePause();
                settings.SetActive(false);
            }
            else if (menu.activeInHierarchy) Application.Quit();
            else if (endGame.activeInHierarchy) endGame.GetComponent<endGameController>().buttonBack();
            else if (game.activeInHierarchy) {
                endGame.GetComponent<endGameController>().activate(game.GetComponent<gameController>().getPoints());
            }
        }
	}
}
