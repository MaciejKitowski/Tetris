using UnityEngine;

//Spawn new block in in block architect
public class DebugBlockSpawner : MonoBehaviour {
    public Sprite blockSprite;

    private BlocksArchitect architectBlock;
    private BlocksSerialization serialization;
    private GameObject parent;
    private GameObject detector;

    void Awake() {
        architectBlock = FindObjectOfType<BlocksArchitect>();
        serialization = FindObjectOfType<BlocksSerialization>();
    }

    public void createBlock() {
        for(int i = 0; i < serialization.blocks.Capacity - 1; ++i)
        {
            parent = createGameObject("Block" + i.ToString(), -2.47f + i, -2.7f);
            parent.AddComponent<Block>();

            createTiles(i);
        }


        //FROM BLOCK ARCHITECT
        /*parent = createGameObject("Block", 0, -2.7f);
        parent.AddComponent<Block>();

        createTiles();

        detector = createGameObjectAsChildren(parent, "Detectors");
        detector.AddComponent<Detector>();

        createDetectorsDown();
        createDetectorsUp();
        createDetectorsLeft();
        createDetectorsRight();
        fixPosition();
        if (architectBlock.canRotate) createDetectorsRotation();
        else createGameObjectAsChildren(detector, "Rotation");

        parent.GetComponent<Block>().enabled = false;
        detector.GetComponent<Detector>().enabled = false;*/
    }

    private void createTiles(int index) {
        float posX = 0;
        float posY = 0;
        bool[,] block = serialization.getConvertedTiles(index);

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0)
        {
            for (int x = 0; x < 6; ++x, posX += 0.38382f)
            {
                if(block[x,y] == true)
                {
                    GameObject buffer = createGameObjectAsChildren(parent, "Tile", posX, posY, 0.3f);
                    buffer.transform.tag = "Game_blockTile";
                    addSprite(buffer);
                    addPhysics(buffer);
                    buffer.AddComponent<BlockTile>();
                    buffer.GetComponent<BlockTile>().enabled = false;
                }
            }
        }


        /*float posX = 0;
        float posY = 0;

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0) {
            for (int x = 0; x < 6; ++x, posX += 0.38382f) {
                if(architectBlock.tile[x,y].pressed) {
                    GameObject buffer = createGameObjectAsChildren(parent, "Tile", posX, posY, 0.3f);
                    buffer.transform.tag = "Game_blockTile";
                    addSprite(buffer);
                    addPhysics(buffer);
                    buffer.AddComponent<BlockTile>();
                    buffer.GetComponent<BlockTile>().enabled = false;
                }
            }
        }*/
    }

    private void createDetectorsDown() {
        GameObject detectorDown = createGameObjectAsChildren(detector, "Down");
        float posX = 0;
        float posY = 0;

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0) {
            for (int x = 0; x < 6; ++x, posX += 0.38382f) {
                if (architectBlock.tile[x, y].pressed && ((y + 1) >= 6 || !architectBlock.tile[x, y + 1].pressed)) createDetector(detectorDown, posX, posY - 0.38382f);
            }
        }
    }

    private void createDetectorsUp() {
        GameObject detectorUp = createGameObjectAsChildren(detector, "Up");
        float posX = 0;
        float posY = 0;

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0) {
            for (int x = 0; x < 6; ++x, posX += 0.38382f) {
                if (architectBlock.tile[x, y].pressed && ((y - 1) <= 0 || !architectBlock.tile[x, y - 1].pressed)) createDetector(detectorUp, posX, posY + 0.38382f);
            }
        }
    }

    private void createDetectorsLeft() {
        GameObject detectorLeft = createGameObjectAsChildren(detector, "Left");
        float posX = 0;
        float posY = 0;

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0) {
            for (int x = 0; x < 6; ++x, posX += 0.38382f) {
                if (architectBlock.tile[x, y].pressed && ((x - 1) <= 0 || !architectBlock.tile[x - 1, y].pressed)) createDetector(detectorLeft, posX - 0.38382f, posY);
            }
        }
    }

    private void createDetectorsRight() {
        GameObject detectorRight = createGameObjectAsChildren(detector, "Right");
        float posX = 0;
        float posY = 0;

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0) {
            for (int x = 0; x < 6; ++x, posX += 0.38382f) {
                if (architectBlock.tile[x, y].pressed && ((x + 1) >= 6 || !architectBlock.tile[x + 1, y].pressed)) createDetector(detectorRight, posX + 0.38382f, posY);
            }
        }
    }

    private void createDetectorsRotation() {
        GameObject detectorRotation = createGameObjectAsChildren(detector, "Rotation");

        GameObject[] blockTiles = new GameObject[parent.transform.childCount - 1];
        for (int i = 0; i < parent.transform.childCount - 1; ++i) blockTiles[i] = parent.transform.GetChild(i).gameObject;

        for (int i = 1; i < blockTiles.Length; ++i) createDetector(detectorRotation, blockTiles[i].transform.localPosition.x, blockTiles[i].transform.localPosition.y);
        detectorRotation.transform.Rotate(new Vector3(0, 0, 90f));
    }

    private void fixPosition() {
        if(parent.transform.GetChild(0).transform.localPosition.x > 0) {
            float positionChangeX = parent.transform.GetChild(0).transform.localPosition.x;

            //Tiles
            foreach (Transform tl in parent.transform) {
                if (tl.name == "Tile") tl.transform.localPosition = new Vector3(tl.transform.localPosition.x - positionChangeX, tl.transform.localPosition.y);
                else break;
            }

            //Detector
            foreach (Transform detect in detector.transform) {
                foreach (Transform tl in detect) tl.transform.localPosition = new Vector3(tl.transform.localPosition.x - positionChangeX, tl.transform.localPosition.y);
            }
        }

        if (parent.transform.GetChild(0).transform.localPosition.y < 0) {
            float positionChangeY = parent.transform.GetChild(0).transform.localPosition.y;

            //Tiles
            foreach (Transform tl in parent.transform) {
                if (tl.name == "Tile") tl.transform.localPosition = new Vector3(tl.transform.localPosition.x, tl.transform.localPosition.y - positionChangeY);
                else break;
            }

            //Detector
            foreach (Transform detect in detector.transform) {
                foreach (Transform tl in detect) tl.transform.localPosition = new Vector3(tl.transform.localPosition.x, tl.transform.localPosition.y - positionChangeY);
            }
        }
    }

    private void addPhysics(GameObject obj) {
        obj.AddComponent<BoxCollider2D>();
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void addSprite(GameObject obj) {
        obj.AddComponent<SpriteRenderer>();
        obj.GetComponent<SpriteRenderer>().sprite = blockSprite;
        obj.GetComponent<SpriteRenderer>().sortingOrder = 4;
        obj.GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void createDetector(GameObject parent, float posX, float posY) {
        GameObject buffer = createGameObjectAsChildren(parent, "Detector", posX, posY, 0.3f);
        buffer.tag = "Game_detector";
        addPhysics(buffer);
        buffer.AddComponent<DetectorTile>();
    }

    private GameObject createGameObject(string name, float posX = 0, float posY = 0) {
        GameObject buffer = new GameObject();
        buffer.name = name;
        buffer.transform.position = new Vector3(posX, posY);

        return buffer;
    }

    private GameObject createGameObjectAsChildren(GameObject par, string name, float posX = 0, float posY = 0, float scale = 1) {
        GameObject buffer = createGameObject(name);
        buffer.transform.SetParent(par.transform);
        buffer.transform.localScale = new Vector3(scale, scale);
        buffer.transform.localPosition = new Vector3(posX, posY);

        return buffer;
    }
}
