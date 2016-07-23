using UnityEngine;
using UnityEngine.UI;

public class BlocksArchitect : MonoBehaviour {
    public CreatorTile[,] tile = new CreatorTile[6, 6];
    public bool canRotate = true;
    public Toggle rotationCheckmark;

    private MainMenu mainMenu;
    private BlocksSerialization serialization;
    private BlocksList blockList;

    void Awake() {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();
        serialization = GetComponent<BlocksSerialization>();
        blockList = GameObject.FindGameObjectWithTag("BlockList").GetComponent<BlocksList>();
        loadTiles();
    }

    public void activate() {
        gameObject.SetActive(true);
        blockList.buttonBack();
        reset();
    }

    public void buttonBack() {
        serialization.save();
        blockList.buttonBack();
        gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void toggleRotation() {
        canRotate = !canRotate;
        rotationCheckmark.isOn = canRotate;
    }

    public void buttonSave() {
        serialization.addNewBlock();
        reset();
    }

    public void buttonList() {
        blockList.gameObject.SetActive(true);
        blockList.loadAll();
    }

    public void reset() { foreach (CreatorTile tl in tile) tl.reset(); }

    public bool isTilePressed() {
        foreach (CreatorTile tl in tile) if (tl.pressed) return true;
        return false;
    }

    private void loadTiles() {
        for(int y = 0; y < 6; ++y) {
            for(int x = 0; x < 6; ++x) tile[x, y] = transform.GetChild(0).GetChild(y).transform.GetChild(x).GetComponent<CreatorTile>();
        }
    }
}
