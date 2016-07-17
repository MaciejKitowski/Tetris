using UnityEngine;

public class BlockOnList : MonoBehaviour {
    private GameObject block;
    private int blockIndex;
    private BlocksSerialization serialization;

    void Awake() {
        block = transform.GetChild(0).gameObject;
        serialization = FindObjectOfType<BlocksSerialization>();
    }

	public void buttonDelete() {
        Debug.Log("Delete block with index - " + blockIndex);
        serialization.blocks.RemoveAt(blockIndex);
        Destroy(gameObject);
    }

    public void load(int index) {
        blockIndex = index;
        float posX = 0;
        float posY = 0;
        bool[,] blockTile = serialization.getConvertedTiles(index);

        for (int y = 0; y < 6; ++y, posY -= 0.38382f, posX = 0) {
            for (int x = 0; x < 6; ++x, posX += 0.38382f) {
                if (blockTile[x, y] == true) {
                    GameObject buffer = new GameObject();
                    buffer.name = "Tile";
                    buffer.transform.SetParent(block.transform);
                    buffer.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    buffer.transform.localPosition = new Vector3(posX, posY);

                    buffer.AddComponent<SpriteRenderer>();
                    buffer.GetComponent<SpriteRenderer>().sprite = serialization.blockSprite;
                    buffer.GetComponent<SpriteRenderer>().sortingOrder = 10;
                }
            }
        }
    }


}
