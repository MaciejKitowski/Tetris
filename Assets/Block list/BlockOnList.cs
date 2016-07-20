using UnityEngine;
using UnityEngine.UI;

public class BlockOnList : MonoBehaviour {
    private GameObject block;
    private int blockIndex;
    private BlocksSerialization serialization;

    void Awake() {
        block = transform.GetChild(0).gameObject;
        serialization = FindObjectOfType<BlocksSerialization>();
    }

	public void buttonDelete() {
        serialization.blocks.RemoveAt(blockIndex);
        Destroy(gameObject);
    }

    public void load(int index) {
        blockIndex = index;
        if (!serialization.blocks[index].deletable) transform.GetChild(1).GetComponent<Button>().interactable = false;

        GameObject buffer = BlockDeserialization.CreateBlock(blockIndex);
        buffer.transform.SetParent(block.transform);
        buffer.transform.localPosition = new Vector3();
        buffer.transform.localScale = new Vector3(1, 1, 1);
    }
}
