using UnityEngine;

//Spawn new block in in block architect
public class DebugBlockSpawner : MonoBehaviour {
    public Sprite blockSprite;

    private BlocksArchitect architectBlock;
    private GameObject parent;
    private GameObject detector;

    void Awake() { architectBlock = FindObjectOfType<BlocksArchitect>(); }

    public void createBlock() {
        parent = createGameObject("Block", 0, -2.7f);
        parent.AddComponent<Block>();

        createTiles();

        detector = createGameObjectAsChildren(parent, "Detectors");
        detector.AddComponent<Detector>();

        createDetectorsDown();
        createDetectorsUp();
        createDetectorsLeft();
        createDetectorsRight();

        parent.GetComponent<Block>().enabled = false;
        detector.GetComponent<Detector>().enabled = false;
    }

    private void createTiles() {
        float posX = 0;
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
        }
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
        buffer.transform.position = new Vector3(0, posY);

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
