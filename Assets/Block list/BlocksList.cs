using UnityEngine;

public class BlocksList : MonoBehaviour {
    public GameObject listPrefab;
    public float swipeSpeed = 6f;

    private BlocksSerialization serialization;
    private Transform blocksContainer;

    void Awake() {
        serialization = GameObject.FindGameObjectWithTag("BlockArchitect").GetComponent<BlocksSerialization>();
        blocksContainer = transform.GetChild(0).transform.GetChild(2);
    }

    void Update() { swipeMovement(); }

    public void buttonBack() {
        gameObject.SetActive(false);
        deleteList();
    }

    public void loadAll() {
        float posY = 0;

        for(int i = 0; i < serialization.blockCount(); ++i, posY -= 50f) {
            GameObject buffer = Instantiate(listPrefab) as GameObject;
            buffer.transform.SetParent(blocksContainer);
            buffer.transform.localScale = new Vector3(1, 1, 1);
            buffer.transform.localPosition = new Vector3(0, 100 + posY, 0);

            buffer.GetComponent<BlockOnList>().load(i);
        }
    }

    private void swipeMovement() {
        if (isActiveAndEnabled && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 positon = Input.GetTouch(0).deltaPosition;
            if (positon.y > 1) swipeUp();
            else if (positon.y < -1) swipeDown();
        }
    }

    private void deleteList() { foreach (Transform obj in blocksContainer) Destroy(obj.gameObject); }
    private void swipeUp() { blocksContainer.Translate(Vector3.up * Time.deltaTime * swipeSpeed); }
    private void swipeDown() { blocksContainer.Translate(Vector3.down * Time.deltaTime * swipeSpeed); }
}
