using UnityEngine;
using System.Collections;

public class nextBlockController : MonoBehaviour {
    public GameObject[] blockPrefabs;

    void Awake() { if (transform.childCount == 0) randNew(); }

    public void randNew() {
        if(transform.childCount > 0) foreach (Transform obj in transform) Destroy(obj.gameObject);
        int index = Random.Range(0, blockPrefabs.Length);

        GameObject buffer = Instantiate(blockPrefabs[index]) as GameObject;
        buffer.transform.SetParent(transform);
        buffer.transform.localPosition = new Vector2(0, 0);
        
        buffer.GetComponent<Block>().randColor();
        buffer.GetComponent<Block>().enabled = false;
    }

    public GameObject getBlock() { return transform.GetChild(0).gameObject; }
}
