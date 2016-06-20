using UnityEngine;
using System.Collections;

public class exitButtonController : MonoBehaviour {
    private GameObject game;
    private GameObject menu;
    private GameObject settings;

    void Awake() {
        game = GameObject.FindGameObjectWithTag("Game");
        menu = GameObject.FindGameObjectWithTag("MainMenu");
        settings = GameObject.FindGameObjectWithTag("Settings");
        game.SetActive(false);
        settings.SetActive(false);
    }

	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape)) {

            if(settings.activeInHierarchy) {
                settings.GetComponent<settingsController>().saveSettings();
                settings.SetActive(false);
            }
            else if (menu.activeInHierarchy) Application.Quit();
            else if(game.activeInHierarchy) {
                game.SetActive(false);
                menu.SetActive(true);
            }
        }
	}
}
