using UnityEngine;

//Spawn new block in in block architect
public class DebugBlockSpawner : MonoBehaviour {
    public Sprite blockSprite;

    private BlocksArchitect architectBlock;
    private GameObject parent;

    void Awake() { architectBlock = FindObjectOfType<BlocksArchitect>(); }

    public void createBlock() {
        parent = createGameObject("Block", 0, -2.7f);
        parent.AddComponent<Block>();
        parent.GetComponent<Block>().enabled = false;

        createTiles();
    }

    private void createTiles() {
        float posX = 0;
        float posY = 0;

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0) {
            for (int x = 0; x < 6; ++x, posX += 0.38382f) {
                if(architectBlock.tile[x,y].pressed) {
                    GameObject buffer = createGameObjectAsChildren(parent, "Tile", posX, posY, 0.3f);
                    buffer.transform.tag = "Game_blockTile";

                    buffer.AddComponent<SpriteRenderer>();
                    buffer.GetComponent<SpriteRenderer>().sprite = blockSprite;
                    buffer.GetComponent<SpriteRenderer>().sortingOrder = 10;
                    buffer.GetComponent<SpriteRenderer>().color = Color.green;
                    buffer.AddComponent<BoxCollider2D>();
                    buffer.AddComponent<Rigidbody2D>();
                    buffer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    buffer.AddComponent<BlockTile>();
                    buffer.GetComponent<BlockTile>().enabled = false;
                }
            }
        }
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
        buffer.transform.localScale = new Vector3(0.3f, 0.3f);
        buffer.transform.localPosition = new Vector3(posX, posY);

        return buffer;
    }
}
