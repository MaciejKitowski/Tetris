using UnityEngine;

public class nextBlockController : MonoBehaviour {
    private BlocksSerialization serialization;

    void Awake() { serialization = FindObjectOfType<BlocksSerialization>(); }

    public void randNew() {
        if(transform.childCount > 0) foreach (Transform obj in transform) Destroy(obj.gameObject);
        int index = Random.Range(0, serialization.blocks.Count);

        GameObject buffer = BlockDeserialization.CreateBlock(index, true);
        buffer.transform.SetParent(transform);
        buffer.transform.localPosition = new Vector2(0, 0);
        buffer.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        buffer.GetComponent<Block>().randColor();
        buffer.GetComponent<Block>().enabled = false;
    }

    public GameObject getBlock() { return transform.GetChild(0).gameObject; }
}
