using UnityEngine;

public class BlocksList : MonoBehaviour {
    public GameObject listPrefab;
    public float swipeSpeed = 6f;

    private BlocksSerialization serialization;

    void Awake() { serialization = FindObjectOfType<BlocksSerialization>(); }
    void Update() { swipeMovement(); }

    public void buttonBack() { gameObject.SetActive(false); }

    public void loadAll() {
        if (transform.GetChild(0).transform.childCount > 2) deleteList();
        float posY = 0;

        for(int i = 0; i < serialization.blockCount(); ++i, posY -= 50f) {
            GameObject buffer = Instantiate(listPrefab) as GameObject;
            buffer.transform.SetParent(transform.GetChild(0));
            buffer.transform.localScale = new Vector3(1, 1, 1);
            buffer.transform.localPosition = new Vector3(0, 100 + posY, 0);

            buffer.GetComponent<BlockOnList>().load(i);
        }
    }

    private void deleteList() { for (int i = transform.GetChild(0).transform.childCount - 1; i > 1; --i) Destroy(transform.GetChild(0).transform.GetChild(i).gameObject); }

    private void swipeMovement() {
        if (isActiveAndEnabled && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 positon = Input.GetTouch(0).deltaPosition;
            if (positon.y > 1) swipeUp();
            else if (positon.y < -1) swipeDown();
        }
    }

    private void swipeUp() {
        Transform parent = transform.GetChild(0);
        for(int i = 2; i < parent.childCount; ++i) parent.GetChild(i).Translate(Vector3.up * Time.deltaTime * swipeSpeed);
    }

    private void swipeDown() {
        Transform parent = transform.GetChild(0);
        for (int i = 2; i < parent.childCount; ++i) parent.GetChild(i).Translate(Vector3.down * Time.deltaTime * swipeSpeed);
    }
}
