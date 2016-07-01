﻿using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
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

            if (settings.activeInHierarchy) settings.GetComponent<Settings>().deactivate();
            else if (menu.activeInHierarchy) Application.Quit();
            else if (endGame.activeInHierarchy) endGame.GetComponent<EndGame>().buttonBack();
            else if (game.activeInHierarchy)
            {
                endGame.GetComponent<EndGame>().activate(game.GetComponent<Game>().getPoints());
            }
        }
	}
}