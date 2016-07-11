using UnityEngine;
using UnityEngine.UI;

public class BlocksArchitect : MonoBehaviour {
    public CreatorTile[,] tile = new CreatorTile[6, 6];
    public bool canRotate = true;
    public Toggle rotationCheckmark;

    private MainMenu mainMenu;

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

    public void toggleRotation() {
        canRotate = !canRotate;
        rotationCheckmark.isOn = canRotate;
    }

    public void buttonSave() {
        Debug.Log("Save block");
    }

    public void buttonList() {
        Debug.Log("Blocks list");
    }

    public void reset() { foreach (CreatorTile tl in tile) tl.reset(); }

    private void loadTiles() {
        for(int y = 0; y < 6; ++y) {
            for(int x = 0; x < 6; ++x) tile[x, y] = transform.GetChild(0).GetChild(y).transform.GetChild(x).GetComponent<CreatorTile>();
        }
    }
}
