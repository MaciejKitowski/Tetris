using UnityEngine;
using UnityEngine.UI;

public class BlockOnList : MonoBehaviour {
    private GameObject block;
    private int blockIndex;
    private BlocksSerialization serialization;
    private Button deleteButton;

    void Awake() {
        block = transform.GetChild(0).gameObject;
        serialization = FindObjectOfType<BlocksSerialization>();
        deleteButton = transform.GetChild(1).GetComponent<Button>();
    }

	public void buttonDelete() {
        serialization.delete(blockIndex);
        Destroy(gameObject);
    }

    public void load(int index) {
        blockIndex = index;
        if (!serialization.isDeletable(index)) deleteButton.interactable = false;

        GameObject buffer = BlockDeserialization.CreateBlock(blockIndex, BlockDeserialization.createMode.NOSCRIPT);
        buffer.transform.SetParent(block.transform);
        buffer.transform.localPosition = new Vector3();
        buffer.transform.localScale = new Vector3(1, 1, 1);
    }
}
