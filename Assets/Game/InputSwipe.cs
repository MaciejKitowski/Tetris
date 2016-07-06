using UnityEngine;

public class InputSwipe : MonoBehaviour {
    public float minimumSwipeDistance = 0.65f;

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
        if(activated && Input.touchCount > 0 && isExtraWindowsDisabled()) {
            if (!GamePause.isPaused()) {
                if (isSwipeEnd() && isMovedMinimumDistance()) {
                    if (isSwpiedHorizontal()) swipeHorizontal();
                    else swipeVertical();
                }
            }
            else GamePause.deactivateAnimated();
        }
    }

    public void activate() { activated = true; }
    public void deactivate() { activated = false; }

    private bool isExtraWindowsDisabled() {
        if (!settings.isActive() && !endgame.isActive()) return true;
        else return false;
    }

    private bool isSwipeEnd(){
        if (Input.GetTouch(0).phase == TouchPhase.Began) {
            updatePositionVector(ref touchStartPos);
            return false;
        }
        else if(Input.GetTouch(0).phase == TouchPhase.Ended) {
            updatePositionVector(ref touchEndPos);
            return true;
        }
        return false;
    }

    private bool isMovedMinimumDistance() {
        float movedDistance = Vector2.Distance(Camera.main.ScreenToWorldPoint(touchStartPos), Camera.main.ScreenToWorldPoint(touchEndPos));

        if (movedDistance > minimumSwipeDistance) return true;
        else return false;
    }

    private bool isSwpiedHorizontal() {
        float distanceHorizontal = Mathf.Abs(touchEndPos.x - touchStartPos.x);
        float distanceVertical = Mathf.Abs(touchEndPos.y - touchStartPos.y);

        if (distanceHorizontal > distanceVertical) return true;
        else return false;
    }

    private void swipeHorizontal() {
        if (touchEndPos.x > touchStartPos.x) blocks.getBlock().GetComponent<Block>().turnRight();
        else blocks.getBlock().GetComponent<Block>().turnLeft();
    }

    private void swipeVertical() {
        if (touchEndPos.y > touchStartPos.y) blocks.getBlock().GetComponent<Block>().rotate();
        else blocks.getBlock().GetComponent<Block>().speedUp = true;
    }

    private void updatePositionVector(ref Vector2 toUpdate) { toUpdate = Input.GetTouch(0).position; }
}