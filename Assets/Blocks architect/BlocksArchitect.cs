using UnityEngine;
using System.Collections;

public class BlocksArchitect : MonoBehaviour {
    private MainMenu mainMenu;
    private CreatorTile[,] tile = new CreatorTile[6, 6];

    public Sprite spr;

    void Awake() {
        mainMenu = FindObjectOfType<MainMenu>();
        loadTiles();
    }

    // *************************************************** TEST ****************************************************
    // Create new block based on pressed tiles

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) add();
    }

    void add()
    {
        GameObject parent = new GameObject();
        parent.name = "Block";
        parent.transform.position = new Vector3(0, -2.7f);

        float posX = 0;
        float posY = 0;

        //Create tiles
        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0)
        {
            for (int x = 0; x < 6; ++x, posX += 0.38382f)
            {
                if(tile[x,y].pressed)
                {
                    GameObject obj = new GameObject();
                    obj.transform.SetParent(parent.transform);
                    obj.name = "Tile";

                    obj.AddComponent<SpriteRenderer>();
                    obj.GetComponent<SpriteRenderer>().sprite = spr;
                    obj.GetComponent<SpriteRenderer>().sortingOrder = 10;
                    obj.GetComponent<SpriteRenderer>().color = Color.green;

                    obj.transform.localScale = new Vector3(0.3f, 0.3f);
                    obj.transform.localPosition = new Vector3(posX, posY);
                }
            }
        }

        //Fix tiles position in parent
        if(parent.transform.GetChild(0).transform.localPosition.x > 0)
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
        }


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
