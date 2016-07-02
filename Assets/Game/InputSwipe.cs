using UnityEngine;

public class InputSwipe : MonoBehaviour {
    public float minimumSwipeLength = 0.65f;

    private bool activated = false;
    private EndGame endgame;
    private blocksManager blocks;
    private Settings settings;
    private Vector2 touchStartPos = new Vector2(0, 0);
    private Vector2 touchEndPos = new Vector2(0, 0);

    void Awake() {
        endgame = FindObjectOfType<EndGame>();
        blocks = FindObjectOfType<blocksManager>();
        settings = FindObjectOfType<Settings>();
    }

    void Update() {
        if(activated && Input.touchCount > 0) {
            if (!GamePause.isPaused() && !settings.gameObject.activeInHierarchy && !endgame.gameObject.activeInHierarchy) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) touchStartPos = Input.GetTouch(0).position;
                else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                    touchEndPos = Input.GetTouch(0).position;
                    float movedDistance = Vector2.Distance(Camera.main.ScreenToWorldPoint(touchEndPos), Camera.main.ScreenToWorldPoint(touchStartPos));

                    if(movedDistance > minimumSwipeLength) {
                        if (Mathf.Abs(touchEndPos.x - touchStartPos.x) > Mathf.Abs(touchEndPos.y - touchStartPos.y)) {
                            if (touchEndPos.x > touchStartPos.x) blocks.getBlock().GetComponent<Block>().turnRight();
                            else blocks.getBlock().GetComponent<Block>().turnLeft();
                        }
                        else {
                            if (touchEndPos.y > touchStartPos.y) blocks.getBlock().GetComponent<Block>().rotate();
                            else blocks.getBlock().GetComponent<Block>().speedUp = true;
                        }
                    }
                }
            }
            else if (GamePause.isPaused() && !settings.gameObject.activeInHierarchy && !endgame.gameObject.activeInHierarchy) GamePause.deactivate();
        }
    }

    public void activate() { activated = true; }
    public void deactivate() { activated = false; }
}