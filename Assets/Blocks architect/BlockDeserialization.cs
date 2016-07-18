using UnityEngine;

public class BlockDeserialization : MonoBehaviour {
    private static BlocksSerialization serialization;
    private static Sprite blockSprite;

    private static int blockIndex;
    private static bool[,] blockSerialized;

    private static GameObject block;

    void Awake() {
        serialization = FindObjectOfType<BlocksSerialization>();
        blockSprite = Resources.Load<Sprite>("blockSprite");
    }

    public static GameObject CreateBlock(int index) {
        blockIndex = index;
        blockSerialized = serialization.getConvertedTiles(blockIndex);
        block = createGameObject("Block");
        createTiles();

        return block;
    }

    private static void createTiles() {
        Vector2 pos = new Vector2();

        for (int y = 0; y < 6; ++y, pos.y -= 0.38382f, pos.x = 0) {
            for (int x = 0; x < 6; ++x, pos.x += 0.38382f) {
                if (blockSerialized[x, y]) {
                    GameObject buffer = createGameObjectAsChildren(block, "Tile", pos, 0.3f);
                    buffer.transform.tag = "Game_blockTile";
                    addSprite(buffer);
                }
            }
        }
    }

    private static void addSprite(GameObject obj) {
        obj.AddComponent<SpriteRenderer>();
        obj.GetComponent<SpriteRenderer>().sprite = blockSprite;
        obj.GetComponent<SpriteRenderer>().sortingOrder = 4;
        obj.GetComponent<SpriteRenderer>().color = Color.green;
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
