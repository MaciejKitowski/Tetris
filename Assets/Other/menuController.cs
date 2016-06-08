using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour
{
    private GameObject game;
    private GameObject settings;

    void Awake()
    {
        game = GameObject.FindGameObjectWithTag("Game");
        settings = GameObject.FindGameObjectWithTag("Settings");
    }

    public void buttonStartGame()
    {
        game.SetActive(true);
        game.GetComponent<gameController>().newGame();
        gameObject.SetActive(false);
    }

    public void buttonSettings()
    {
        settings.SetActive(true);
        settings.GetComponent<settingsController>().updateSettings();
        gameObject.SetActive(false);
    }

    public void buttonExitGame() { Application.Quit(); }
}
