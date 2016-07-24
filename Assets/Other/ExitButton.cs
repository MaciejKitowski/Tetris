using UnityEngine;

public class ExitButton : MonoBehaviour {
    private GameObject game;
    private GameObject menu;
    private GameObject settings;
    private GameObject endGame;
    private BlocksArchitect blockCreator;
    private BlocksList blockList;

    void Awake() {
        game = GameObject.FindGameObjectWithTag("Game");
        menu = GameObject.FindGameObjectWithTag("MainMenu");
        settings = GameObject.FindGameObjectWithTag("Settings");
        endGame = GameObject.FindGameObjectWithTag("Game_end");

        blockCreator = GameObject.FindGameObjectWithTag("BlockArchitect").GetComponent<BlocksArchitect>();
        blockList = GameObject.FindGameObjectWithTag("BlockList").GetComponent<BlocksList>();
    }

	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape)) {
            if (settings.activeInHierarchy) settings.GetComponent<Settings>().deactivateAnimated();
            else if (menu.activeInHierarchy) Application.Quit();
            else if (endGame.activeInHierarchy) endGame.GetComponent<EndGame>().buttonBack();
            else if (game.activeInHierarchy) endGame.GetComponent<EndGame>().activate(Points.getPoints());
            else if (blockList.gameObject.activeInHierarchy) blockList.buttonBack();
            else if (blockCreator.gameObject.activeInHierarchy) blockCreator.buttonBack();
        }
	}
}
