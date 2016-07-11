using UnityEngine;
using System.Collections;

public class BlocksArchitect : MonoBehaviour {
    public CreatorTile[,] tile = new CreatorTile[6, 6];

    private MainMenu mainMenu;
    

    public Sprite spr;

    void Awake() {
        mainMenu = FindObjectOfType<MainMenu>();
        loadTiles();
    }

    // *************************************************** TEST ****************************************************
    // Create new block based on pressed tiles
    void add()
    {


        //Fix tiles position in parent
        /*if(parent.transform.GetChild(0).transform.localPosition.x > 0)
        {
            float positionToChange = parent.transform.GetChild(0).transform.localPosition.x;

            foreach (Transform tl in parent.transform)
            {
                tl.transform.localPosition = new Vector3(tl.transform.localPosition.x - positionToChange, tl.transform.localPosition.y);
            }
        }

        if (parent.transform.GetChild(0).transform.localPosition.y < 0)
        {
            float positionToChange = parent.transform.GetChild(0).transform.localPosition.y;

            foreach (Transform tl in parent.transform)
            {
                tl.transform.localPosition = new Vector3(tl.transform.localPosition.x, tl.transform.localPosition.y - positionToChange);
            }
        }*/
    }

    // **************************************************** END ****************************************************

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

    public void reset() { foreach (CreatorTile tl in tile) tl.reset(); }

    private void loadTiles() {
        for(int y = 0; y < 6; ++y) {
            for(int x = 0; x < 6; ++x) tile[x, y] = transform.GetChild(0).GetChild(y).transform.GetChild(x).GetComponent<CreatorTile>();
        }
    }
}
