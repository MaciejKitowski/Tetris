using UnityEngine;
using System.Collections;

public class BlockCreator : MonoBehaviour {
    private MainMenu mainMenu;
    private CreatorTile[,] tile = new CreatorTile[6, 6];

    void Awake() {
        mainMenu = FindObjectOfType<MainMenu>();
        loadTiles();
    }

    public void activate() {
        gameObject.SetActive(true);
        reset();
    }

    public void buttonBack() {
        gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void buttonSave() {
        Debug.Log("Save block");
    }

    public void buttonList() {
        Debug.Log("Blocks list");
    }

    public void reset() {
        Debug.Log("Reset");
    }

    private void loadTiles() {
        for(int y = 0; y < 6; ++y) {
            for(int x = 0; x < 6; ++x) tile[x, y] = transform.GetChild(0).GetChild(y).transform.GetChild(x).GetComponent<CreatorTile>();
        }
    }
}
