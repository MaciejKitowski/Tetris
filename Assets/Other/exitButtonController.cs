using UnityEngine;
using System.Collections;

public class exitButtonController : MonoBehaviour
{
    private GameObject game;
    private GameObject menu;

    void Awake()
    {
        game = GameObject.FindGameObjectWithTag("Game");
        menu = GameObject.FindGameObjectWithTag("MainMenu");
    }

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (game.activeInHierarchy)
            {
                game.SetActive(false);
                menu.SetActive(true);
            }
            else if (menu.activeInHierarchy) Application.Quit();
        }
	}
}
