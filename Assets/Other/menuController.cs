using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour
{
    private GameObject game;

    void Awake()
    {
        game = GameObject.FindGameObjectWithTag("Game");
        game.SetActive(false);
    }

    public void buttonStartGame()
    {
        game.SetActive(true);
        game.GetComponent<gameController>().newGame();
        gameObject.SetActive(false);
    }

    public void buttonSettings()
    {

    }

    public void buttonExitGame()
    {
        Application.Quit();
    }
}
