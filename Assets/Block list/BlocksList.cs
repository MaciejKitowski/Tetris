using UnityEngine;

public class BlocksList : MonoBehaviour {
    public GameObject listPrefab;

    private BlocksSerialization serialization;

    void Awake() {
        serialization = FindObjectOfType<BlocksSerialization>();
    }

    public void buttonBack() {
        gameObject.SetActive(false);
    }

    public void loadAll() {
        if (transform.GetChild(0).transform.childCount > 2) deleteList();

        float positionY = 0;

        for(int i = 0; i < serialization.blocks.Count; ++i, positionY -= 50f) {
            GameObject buffer = Instantiate(listPrefab) as GameObject;
            buffer.transform.SetParent(transform.GetChild(0));
            buffer.transform.localScale = new Vector3(1, 1, 1);
            buffer.transform.localPosition = new Vector3(0, 100 + positionY, 0);

            buffer.GetComponent<BlockOnList>().load(i);
        }
    }

    private void deleteList() { for (int i = transform.GetChild(0).transform.childCount - 1; i > 1; --i) Destroy(transform.GetChild(0).transform.GetChild(i).gameObject); }
}
