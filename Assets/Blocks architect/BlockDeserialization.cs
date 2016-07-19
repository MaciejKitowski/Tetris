using UnityEngine;

public class BlockDeserialization : MonoBehaviour {
    private static BlocksSerialization serialization;
    private static Sprite blockSprite;

    private static int blockIndex;
    private static bool[,] blockSerialized;

    private static GameObject block;
    private static GameObject detectors;

    void Awake() {
        serialization = FindObjectOfType<BlocksSerialization>();
        blockSprite = Resources.Load<Sprite>("blockSprite");
    }

    public static GameObject CreateBlock(int index, bool complete = false) {
        blockIndex = index;
        blockSerialized = serialization.getConvertedTiles(blockIndex);
        block = createGameObject("Block");
        createTiles(complete);

        if(complete) {
            block.AddComponent<Block>();
            detectors = createGameObjectAsChildren(block, "Detectors");
            detectors.AddComponent<Detector>();

            createDetectorsDown();
            createDetectorsUp();
            createDetectorsLeft();
            createDetectorsRight();

            if (serialization.blocks[blockIndex].canRotate) createDetectorsRotation();
            else createGameObjectAsChildren(detectors, "Rotation");

            //block.GetComponent<Block>().enabled = false;
            //detectors.GetComponent<Detector>().enabled = false;
        }

        fixPosition();
        return block;
    }

    private static void createTiles(bool complete) {
        Vector2 pos = new Vector2();

        for (int y = 0; y < 6; ++y, pos.y -= 0.38382f, pos.x = 0) {
            for (int x = 0; x < 6; ++x, pos.x += 0.38382f) {
                if (blockSerialized[x, y]) {
                    GameObject buffer = createGameObjectAsChildren(block, "Tile", pos, 0.3f);
                    buffer.transform.tag = "Game_blockTile";
                    addSprite(buffer);

                    if (complete) {
                        addPhysics(buffer);
                        buffer.AddComponent<BlockTile>();
                        //buffer.GetComponent<BlockTile>().enabled = false;
                    }
                }
            }
        }
    }

    private static void createDetectorsDown() {
        GameObject detectorTiles = createGameObjectAsChildren(detectors, "Down");
        Vector2 pos = new Vector2();

        for (int y = 0; y < 6; ++y, pos.y -= 0.38382f, pos.x = 0) {
            for (int x = 0; x < 6; ++x, pos.x += 0.38382f) {
                if (blockSerialized[x, y] && ((y + 1) >= 6 || !blockSerialized[x, y + 1])) createDetector(detectorTiles, new Vector2(pos.x, pos.y - 0.38382f));
            }
        }
    }

    private static void createDetectorsUp() {
        GameObject detectorTiles = createGameObjectAsChildren(detectors, "Up");
        Vector2 pos = new Vector2();

        for (int y = 0; y < 6; ++y, pos.y -= 0.38382f, pos.x = 0) {
            for (int x = 0; x < 6; ++x, pos.x += 0.38382f) {
                if (blockSerialized[x, y] && ((y - 1) < 0 || !blockSerialized[x, y - 1])) createDetector(detectorTiles, new Vector2(pos.x, pos.y + 0.38382f));
            }
        }
    }

    private static void createDetectorsLeft() {
        GameObject detectorTiles = createGameObjectAsChildren(detectors, "Left");
        Vector2 pos = new Vector2();

        for (int y = 0; y < 6; ++y, pos.y -= 0.38382f, pos.x = 0) {
            for (int x = 0; x < 6; ++x, pos.x += 0.38382f) {
                if (blockSerialized[x, y] && ((x - 1) < 0 || !blockSerialized[x - 1, y])) createDetector(detectorTiles, new Vector2(pos.x - 0.38382f, pos.y));
            }
        }
    }

    private static void createDetectorsRight() {
        GameObject detectorTiles = createGameObjectAsChildren(detectors, "Right");
        Vector2 pos = new Vector2();

        for (int y = 0; y < 6; ++y, pos.y -= 0.38382f, pos.x = 0) {
            for (int x = 0; x < 6; ++x, pos.x += 0.38382f) {
                if (blockSerialized[x, y] && ((x + 1) >= 6 || !blockSerialized[x + 1, y])) createDetector(detectorTiles, new Vector2(pos.x + 0.38382f, pos.y));
            }
        }
    }

    private static void createDetectorsRotation() {
        GameObject detectorRotation = createGameObjectAsChildren(detectors, "Rotation");

        GameObject[] blockTiles = new GameObject[block.transform.childCount - 1];
        for (int i = 0; i < block.transform.childCount - 1; ++i) blockTiles[i] = block.transform.GetChild(i).gameObject;

        for (int i = 0; i < blockTiles.Length; ++i) createDetector(detectorRotation, blockTiles[i].transform.localPosition);
        detectorRotation.transform.Rotate(new Vector3(0, 0, 90f));
    }

    private static void fixPosition() {
        if (block.transform.GetChild(0).transform.localPosition.x > 0) {
            float positionChangeX = block.transform.GetChild(0).transform.localPosition.x;

            //Tiles
            foreach (Transform tl in block.transform) {
                if (tl.name == "Tile") tl.transform.localPosition = new Vector3(tl.transform.localPosition.x - positionChangeX, tl.transform.localPosition.y);
                else break;
            }

            //Detector
            foreach (Transform detect in detectors.transform) {
                foreach (Transform tl in detect) tl.transform.localPosition = new Vector3(tl.transform.localPosition.x - positionChangeX, tl.transform.localPosition.y);
            }
        }

        if (block.transform.GetChild(0).transform.localPosition.y < 0) {
            float positionChangeY = block.transform.GetChild(0).transform.localPosition.y;

            //Tiles
            foreach (Transform tl in block.transform) {
                if (tl.name == "Tile") tl.transform.localPosition = new Vector3(tl.transform.localPosition.x, tl.transform.localPosition.y - positionChangeY);
                else break;
            }

            //Detector
            foreach (Transform detect in detectors.transform) {
                foreach (Transform tl in detect) tl.transform.localPosition = new Vector3(tl.transform.localPosition.x, tl.transform.localPosition.y - positionChangeY);
            }
        }
    }

    private static void addSprite(GameObject obj) {
        obj.AddComponent<SpriteRenderer>();
        obj.GetComponent<SpriteRenderer>().sprite = blockSprite;
        obj.GetComponent<SpriteRenderer>().sortingOrder = 4;
        obj.GetComponent<SpriteRenderer>().color = Color.green;
    }

    private static void addPhysics(GameObject obj) {
        obj.AddComponent<BoxCollider2D>();
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        obj.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
    }

    private static void createDetector(GameObject parent, Vector2 pos = default(Vector2)) {
        GameObject buffer = createGameObjectAsChildren(parent, "Detector", pos, 0.3f);
        buffer.tag = "Game_detector";
        addPhysics(buffer);
        buffer.AddComponent<DetectorTile>();
    }

    private static GameObject createGameObject(string name, Vector2 pos = default(Vector2)) {
        GameObject buffer = new GameObject();
        buffer.name = name;
        buffer.transform.position = new Vector3(pos.x, pos.y);

        return buffer;
    }

    private static GameObject createGameObjectAsChildren(GameObject par, string name, Vector2 pos = default(Vector2), float scale = 1) {
        GameObject buffer = createGameObject(name);
        buffer.transform.SetParent(par.transform);
        buffer.transform.localScale = new Vector3(scale, scale);
        buffer.transform.localPosition = new Vector3(pos.x, pos.y);

        return buffer;
    }
}
