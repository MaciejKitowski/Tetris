using UnityEngine;
using System.Collections;

public class nextBlockController : MonoBehaviour {
    public GameObject[] blockPrefabs;

    void Awake() { if (transform.childCount == 0) randNew(); }

	void Update () {
        if (Input.GetKeyDown(KeyCode.F)) randNew();
        if (Input.GetKeyDown(KeyCode.Alpha1)) randNew(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) randNew(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) randNew(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) randNew(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) randNew(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) randNew(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) randNew(6);
    }

    public void randNew(int index = 9) {
        if(transform.childCount > 0) foreach (Transform obj in transform) Destroy(obj.gameObject);
        if (index == 9) index = Random.Range(0, 7);

        GameObject buffer = Instantiate(blockPrefabs[index]) as GameObject;
        buffer.transform.SetParent(transform);
        buffer.transform.localPosition = new Vector2(0, 0);
        
        buffer.GetComponent<Block>().randColor();
        buffer.GetComponent<Block>().enabled = false;
    }

    public GameObject getBlock() { return transform.GetChild(0).gameObject; }
}
